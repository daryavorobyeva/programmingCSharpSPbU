namespace SimpleList.Tests;

[TestClass()]
public class ListTest
{
    List list;

    [TestInitialize]
    public void Initialize()
    {
        list = new List();
    }

    [TestMethod()]
    public void AddTest()
    {
        list.Add(5);
        list.Add(7);
        Assert.AreEqual(2, list.Size);
    }

    [TestMethod()]
    public void RemoveTestEmptyList()
    {
        var ex = Assert.ThrowsException<InvalidOperationException>(() => list.Remove());
        Assert.AreEqual(ex.Message, "The list is empty.");
    }

    [TestMethod()]
    public void RemoveTestOneElementInTheList()
    {
        list.Add(5);
        list.Remove();
        Assert.AreEqual(0, list.Size);
    }

    [TestMethod()]
    public void RemoveTestMoreElementsInTheList()
    {
        list.Add(5);
        list.Add(6);
        list.Remove();
        Assert.AreEqual(1, list.Size);
    }

    [TestMethod()]
    public void ReplaceTestWrongPosition()
    {
        list.Add(5);

        var ex = Assert.ThrowsException<IndexOutOfRangeException>(() => list.Replace(7, 10));
        Assert.AreEqual(ex.Message, "Invalid item position number.");
    }
}