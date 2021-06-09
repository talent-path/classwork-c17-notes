using NUnit.Framework;
using WidgetSales;

namespace WidgetSalesTests
{
    public class InMemInventoryDaoTests
    {
        InMemInventoryDao _toTest;

        [SetUp]
        public void Setup()
        {
            _toTest = new InMemInventoryDao();
        }

        [TestCase( "lumber", 1, "building supplies", 1)]
        public void TestAddWidgetInventory(string name, int qty, string cat, int expectedId )
        {
            WidgetInventory toAdd = new WidgetInventory {
                Category = cat,
                Name = name,
                StockCount = qty };
            int addedId = _toTest.Add(toAdd);

            WidgetInventory savedWidget = _toTest.GetByName(name);


            Assert.AreEqual(expectedId, addedId);
            Assert.AreEqual(savedWidget.Name, name);
            Assert.AreEqual(savedWidget.Category, cat);
            Assert.AreEqual(savedWidget.Id, expectedId);
            Assert.AreEqual(savedWidget.StockCount, qty);
        }

        [Test]
        public void ShouldNotBeAbleToChangeAddedWidget()
        {
            WidgetInventory toAdd = new WidgetInventory
            {
                Category = "test",
                Name = "test",
                StockCount = 1
            };

            _toTest.Add(toAdd);

            toAdd.Name = "x";

            var storedWidget = _toTest.GetByName("test");
            Assert.AreEqual("test", storedWidget.Name);
        }


    }
}