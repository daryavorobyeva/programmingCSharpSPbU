namespace StackImplementation.Tests;

[TestClass]
public class StackArrayTest
{
    private StackArray stack;

    [TestInitialize]
    public void Initialize()
    {
        stack = new StackArray();
    }

    [TestMethod]
    public void PushTest()
    {
        Assert.IsTrue(stack.IsEmpty());
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestMethod]
    public void PopTest()
    {
        stack.Push(1);
        var result = stack.Pop();
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void PopTestWithTwoElements()
    {
        stack.Push(1);
        stack.Push(2);
        Assert.AreEqual(stack.Pop(), 2);
        Assert.AreEqual(stack.Pop(), 1);
    }

    [TestMethod]
    public void PopTestWithNoPush()
    {
        var ex = Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        Assert.AreEqual(ex.Message, "Can't pop, the stack is empty.");
    }

    [TestMethod]
    public void IsEmptyTest()
    {
        Assert.IsTrue(stack.IsEmpty());
    }
}