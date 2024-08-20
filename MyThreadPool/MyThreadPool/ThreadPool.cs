using System.Collections.Concurrent;
using Task;

namespace ThreadPool;

public class MyThreadPool
{
    private readonly ConcurrentQueue<Action> tasks;
    private readonly Thread[] threads;
    private readonly CancellationTokenSource cts;
    private readonly object lockObject;
    private volatile bool isShutdown = true;

    public MyThreadPool(int threadsNumber)
    {
        if (threadsNumber < 1)
        {
            throw new ArgumentException("There must be at least one thread in the thread pool.");
        }

        isShutdown = false;
        tasks = new();
        threads = new Thread[threadsNumber];
        cts = new();
        lockObject = new();

        for (int i = 0; i < threadsNumber; i++)
        {
            threads[i] = new Thread(Work);
            threads[i].IsBackground = true;
            threads[i].Start();
        }
    }

    public IMyTask<TResult> Submit<TResult>(Func<TResult> function)
    {
        cts.Token.ThrowIfCancellationRequested();

        lock (lockObject)
        {
            cts.Token.ThrowIfCancellationRequested();

            var myTask = new MyTask<TResult>(function, this);
            tasks.Enqueue(myTask.Execute);
            Monitor.Pulse(lockObject);

            return myTask;
        }
    }

    private void SubmitContinuation(Action action)
    {
        cts.Token.ThrowIfCancellationRequested();

        lock (lockObject)
        {
            cts.Token.ThrowIfCancellationRequested();

            tasks.Enqueue(action);
            Monitor.Pulse(lockObject);
        }
    }

    public void Shutdown()
    {
        lock (lockObject)
        {
            cts.Cancel();
            Monitor.PulseAll(lockObject);
            isShutdown = true;
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    private void Work()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            Action? action = null;
            lock (lockObject)
            {
                while (!tasks.TryDequeue(out action) && !cts.Token.IsCancellationRequested)
                {
                    Monitor.Wait(lockObject);
                }
            }
            action?.Invoke();
        }
    }

    public class MyTask<TResult> : IMyTask<TResult>
    {
        private readonly Func<TResult> function;
        private readonly MyThreadPool myThreadPool;
        private TResult result;
        private volatile bool isCompleted = false;
        private Exception? exception;
        private readonly ConcurrentQueue<Action> continuingTasks = new();
        private readonly object taskLockObject = new();

        public MyTask(Func<TResult> function, MyThreadPool threadPool)
        {
            this.function = function;
            myThreadPool = threadPool;
        }

        public TResult? Result
        {
            get
            {
                lock (taskLockObject)
                {
                    while (!isCompleted)
                    {
                        Monitor.Wait(taskLockObject);
                    }

                    if (exception is not null)
                    {
                        throw new AggregateException(exception);
                    }

                    return result;
                }
            }
        }

        public bool IsCompleted => isCompleted;

        public void Execute()
        {
            try
            {
                result = function();
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                lock (taskLockObject)
                {
                    isCompleted = true;
                    Monitor.Pulse(taskLockObject);
                    ExecuteContinuation();
                }
            }
        }

        public void ExecuteContinuation()
        {
            foreach (var task in continuingTasks)
            {
                myThreadPool.tasks.Enqueue(task);
            }
        }

        public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult?, TNewResult> continueFunction)
        {
            if (myThreadPool.isShutdown)
            {
                throw new InvalidOperationException("Thread pool was shut down.");
            }

            lock (taskLockObject)
            {
                var continuationTask = new MyTask<TNewResult>(() => continueFunction(Result), myThreadPool);

                if (isCompleted)
                {
                    myThreadPool.SubmitContinuation(continuationTask.Execute);
                }
                else
                {
                    continuingTasks.Enqueue(continuationTask.Execute);
                }

                return continuationTask;
            }
        }
    }
}
