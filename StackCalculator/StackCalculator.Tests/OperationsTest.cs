namespace StackCalculation.Tests;

[TestClass]
public class OperationTest
{
    int firstPositiveInt = 1;
    int secondPositiveInt = 2;

    int firstNegativeInt = -1;
    int secondNegativeInt = -2;

    double firstPositiveDouble = 3.6;
    double secondPositiveDouble = 1.2;

    double firstNegativeDouble = -3.6;
    double secondNegativeDouble = -1.2;

    double eps = 1e-8;

    double zeroDouble = 0;
    int zeroInt = 0;

    string wrongSymbol = "$";

    [TestMethod]
    public void OperationTestAdditionWithTwoPositiveInt()
    {
        var result = Operations.Operation(firstPositiveInt, secondPositiveInt, "+");
        Assert.AreEqual(result, 3);
    }

    [TestMethod]
    public void OperationTestAdditionWithTwoNegativeInt()
    {
        var result = Operations.Operation(firstNegativeInt, secondNegativeInt, "+");
        Assert.AreEqual(result, -3);
    }

    [TestMethod]
    public void OperationTestAdditionWithTwoPositiveDouble()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveDouble, "+");
        Assert.AreEqual(result, 4.8, eps);
    }

    [TestMethod]
    public void OperationTestAdditionWithTwoNegativeDouble()
    {
        var result = Operations.Operation(firstNegativeDouble, secondNegativeDouble, "+");
        Assert.AreEqual(result, -4.8, eps);
    }

    [TestMethod]
    public void OperationTestAdditionWithIntAndDoubleOneSign()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveInt, "+");
        Assert.AreEqual(result, 5.6, eps);
    }

    [TestMethod]
    public void OperationTestAdditionWithIntAndDoubleDifferentSigns()
    {
        var result = Operations.Operation(firstNegativeDouble, secondPositiveInt, "+");
        Assert.AreEqual(result, -1.6, eps);
    }

    [TestMethod]
    public void OperationTestSubtractionWithTwoPositiveInt()
    {
        var result = Operations.Operation(firstPositiveInt, secondPositiveInt, "-");
        Assert.AreEqual(result, 1);
    }

    [TestMethod]
    public void OperationTestSubtractionWithTwoNegativeInt()
    {
        var result = Operations.Operation(firstNegativeInt, secondNegativeInt, "-");
        Assert.AreEqual(result, -1);
    }

    [TestMethod]
    public void OperationTestSubtractionWithTwoPositiveDouble()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveDouble, "-");
        Assert.AreEqual(result, -2.4, eps);
    }

    [TestMethod]
    public void OperationTestSubtractionWithTwoNegativeDouble()
    {
        var result = Operations.Operation(firstNegativeDouble, secondNegativeDouble, "-");
        Assert.AreEqual(result, 2.4, eps);
    }

    [TestMethod]
    public void OperationTestSubtractionWithIntAndDoubleOneSign()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveInt, "-");
        Assert.AreEqual(result, -1.6, eps);
    }

    [TestMethod]
    public void OperationTestSubtractionWithIntAndDoubleDifferentSigns()
    {
        var result = Operations.Operation(firstNegativeDouble, secondPositiveInt, "-");
        Assert.AreEqual(result, 5.6, eps);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithTwoPositiveInt()
    {
        var result = Operations.Operation(firstPositiveInt, secondPositiveInt, "*");
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithTwoNegativeInt()
    {
        var result = Operations.Operation(firstNegativeInt, secondNegativeInt, "*");
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithTwoPositiveDouble()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveDouble, "*");
        Assert.AreEqual(result, 4.32, eps);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithTwoNegativeDouble()
    {
        var result = Operations.Operation(firstNegativeDouble, secondNegativeDouble, "*");
        Assert.AreEqual(result, 4.32, eps);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithIntAndDoubleOneSign()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveInt, "*");
        Assert.AreEqual(result, 7.2, eps);
    }

    [TestMethod]
    public void OperationTestMultiplicationWithIntAndDoubleDifferentSigns()
    {
        var result = Operations.Operation(firstNegativeDouble, secondPositiveInt, "*");
        Assert.AreEqual(result, -7.2, eps);
    }

    [TestMethod]
    public void OperationTestDivisionWithTwoPositiveInt()
    {
        var result = Operations.Operation(firstPositiveInt, secondPositiveInt, "/");
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void OperationTestDivisionWithTwoNegativeInt()
    {
        var result = Operations.Operation(firstNegativeInt, secondNegativeInt, "/");
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void OperationTestDivisionWithTwoPositiveDouble()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveDouble, "/");
        Assert.AreEqual(result, 0.33333333, eps);
    }

    [TestMethod]
    public void OperationTestDivisionWithTwoNegativeDouble()
    {
        var result = Operations.Operation(firstNegativeDouble, secondNegativeDouble, "/");
        Assert.AreEqual(result, 0.33333333, eps);
    }

    [TestMethod]
    public void OperationTestDivisionWithIntAndDoubleOneSign()
    {
        var result = Operations.Operation(firstPositiveDouble, secondPositiveInt, "/");
        Assert.AreEqual(result, 0.55555555, eps);
    }

    [TestMethod]
    public void OperationTestDivisionWithIntAndDoubleDifferentSigns()
    {
        var result = Operations.Operation(firstNegativeDouble, secondPositiveInt, "/");
        Assert.AreEqual(result, -0.55555555, eps);
    }

    [TestMethod]
    public void OperationTestDivisionByZeroIntAndPositiveInt()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroInt, secondPositiveInt, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionByZeroIntAndNegativeInt()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroInt, secondNegativeInt, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionByZeroIntAndPositiveDouble()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroInt, secondPositiveDouble, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionByZeroIntAndNegativeDouble()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroInt, secondNegativeDouble, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionByZeroDoubleAndInt()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroDouble, secondPositiveInt, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionByZeroDoubleAndDouble()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroDouble, secondNegativeDouble, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionZeroByZeroInt()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroInt, zeroInt, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestDivisionZeroByZeroDouble()
    {
        var ex = Assert.ThrowsException<DivideByZeroException>(() => Operations.Operation(zeroDouble, zeroDouble, "/"));
        Assert.AreEqual(ex.Message, "Сan't be divided by zero.");
    }

    [TestMethod]
    public void OperationTestWrongSymbol()
    {
        var ex = Assert.ThrowsException<InvalidOperationException>(() => Operations.Operation(firstPositiveDouble, secondNegativeDouble, wrongSymbol));
        Assert.AreEqual(ex.Message, "Incorrect character.");
    }
}