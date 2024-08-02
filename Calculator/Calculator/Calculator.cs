using System.ComponentModel;

namespace Calculator;

/// <summary>
/// Calculator for operations of addition, subtraction, 
/// multiplication, division, sign change.
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    private readonly HashSet<string> availableOperation = new HashSet<string> { "+", "-", "*", "/", "+/-" };

    private const string errorMessage = "Error!";

    /// <summary>
    /// Calculator states: operation processing and value processing.
    /// </summary>
    private enum CalculatorStates
    {
        ProcessingTheOperation,
        ProcessingTheValue
    }

    private CalculatorStates currentState = CalculatorStates.ProcessingTheValue;

    private CalculatorOperations.Operations previousOperation = CalculatorOperations.Operations.Addition;

    private string displayMessage = "0";

    private double result = 0;
    private double tempValue = 0;

    /// <summary>
    /// Event for data binding with user.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Property that notifies of its change.
    /// </summary>
    public string Message
    {
        get
        {
            return displayMessage;
        }

        private set
        {
            displayMessage = displayMessage == "-0" ? "0" : value;
            OnPropertyChanged("Message");
        }
    }

    /// <summary>
    /// Add a digit to the right.
    /// </summary>
    /// <param name="digit"></param>
    public void AddDigit(char digit)
    {
        if (!char.IsDigit(digit))
        {
            Message = errorMessage;
        }

        else
        {
            if (currentState == CalculatorStates.ProcessingTheOperation)
            {
                currentState = CalculatorStates.ProcessingTheValue;
            }

            if (Math.Sign(tempValue) >= 0)
            {
                tempValue = tempValue * 10 + (digit - '0');
            }
            else
            {
                tempValue = tempValue * 10 - (digit - '0');
            }

            Message = tempValue.ToString();
        }
    }

    /// <summary>
    /// Add a new operation and calculate the previous operation.
    /// </summary>
    /// <param name="operation"></param>
    public void AddOperation(string operation)
    {
        if (!availableOperation.Contains(operation))
        {
            Message = errorMessage;
        }

        else if (operation == "+/-")
        {
            if (currentState == CalculatorStates.ProcessingTheOperation)
            {
                result = CalculatorOperations.Calculate(CalculatorOperations.Operations.ChangeSign, result);
                Message = Math.Round(result, 9).ToString();
            }
            else
            {
                tempValue = (int)CalculatorOperations.Calculate(CalculatorOperations.Operations.ChangeSign, tempValue);
                Message = Math.Round(tempValue, 9).ToString();
            }
        }

        else
        {
            if (currentState == CalculatorStates.ProcessingTheValue)
            {
                try
                {
                    result = CalculatorOperations.Calculate(previousOperation, result, tempValue);
                    tempValue = 0;
                    Message = result.ToString();
                }
                catch (DivideByZeroException)
                {
                    Message = errorMessage;
                }
            }

            currentState = CalculatorStates.ProcessingTheOperation;
            previousOperation = operation switch
            {
                "+" => CalculatorOperations.Operations.Addition,
                "-" => CalculatorOperations.Operations.Subtraction,
                "*" => CalculatorOperations.Operations.Multiplication,
                "/" => CalculatorOperations.Operations.Division,
                _ => CalculatorOperations.Operations.Addition
            };
        }
    }

    /// <summary>
    /// Calculates current operation.
    /// </summary>
    public void CalculateResult()
    {
        try
        {
            result = CalculatorOperations.Calculate(previousOperation, result, tempValue);
            Message = Math.Round(result, 9).ToString();

            tempValue = 0;
            currentState = CalculatorStates.ProcessingTheOperation;
            previousOperation = CalculatorOperations.Operations.Addition;
        }
        catch (Exception ex) when (ex is ArgumentException || ex is DivideByZeroException)
        {
            Message = errorMessage;
        }
    }

    /// <summary>
    /// Clears the entire calculator field.
    /// </summary>
    public void Clear()
    {
        result = 0;
        tempValue = 0;

        currentState = CalculatorStates.ProcessingTheValue;
        previousOperation = CalculatorOperations.Operations.Addition;

        Message = "0";
    }
}