using StackImplementation;

namespace StackCalculation.Tests;

[TestClass]
public class StackCalculatorTest
{
    StackArray stackArray;
    StackList stackList;

    string correctExpression = "1 2 3 * +";
    string emptyExpression = "";
    string? nullExpression = null;
    string wrongExpression = "1 2 3 *";

    [TestInitialize]
    public void Initialize()
    {
        stackArray = new StackArray();
        stackList = new StackList();
    }

    [TestMethod]
    public void CorrectExpressionArray()
    {
        var result = StackCalculator.CalculateExpression(correctExpression, stackArray);
        Assert.AreEqual(result, 7);
    }

    [TestMethod]
    public void WrongExpressionArray()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => StackCalculator.CalculateExpression(wrongExpression, stackArray));
        Assert.AreEqual(ex.Message, "The expression was written incorrectly.");
    }

    [TestMethod]
    public void EmptyExpressionArray()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => StackCalculator.CalculateExpression(emptyExpression, stackArray));
        Assert.AreEqual(ex.Message, "Expression can`t be empty.");
    }

    [TestMethod]
    public void NullExpressionArray()
    {
        var ex = Assert.ThrowsException<ArgumentNullException>(() => StackCalculator.CalculateExpression(nullExpression, stackArray));
        Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'Expression can`t be null.')");
    }

    [TestMethod]
    public void CorrectExpressionList()
    {
        var result = StackCalculator.CalculateExpression(correctExpression, stackList);
        Assert.AreEqual(result, 7);
    }

    [TestMethod]
    public void WrongExpressionList()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => StackCalculator.CalculateExpression(wrongExpression, stackList));
        Assert.AreEqual(ex.Message, "The expression was written incorrectly.");
    }

    [TestMethod]
    public void EmptyExpressionList()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => StackCalculator.CalculateExpression(emptyExpression, stackList));
        Assert.AreEqual(ex.Message, "Expression can`t be empty.");
    }

    [TestMethod]
    public void NullExpressionList()
    {
        var ex = Assert.ThrowsException<ArgumentNullException>(() => StackCalculator.CalculateExpression(nullExpression, stackList));
        Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'Expression can`t be null.')");
    }
}
