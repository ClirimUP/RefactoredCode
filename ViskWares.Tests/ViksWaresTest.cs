using NUnit.Framework;
using System.Collections.Generic;
using ViksWares.Application;
using ViksWares.Domain.Models;

namespace ViksWares.Tests
    //Tests need to be edited.
{
    [TestFixture]
    public class ViksWaresTest
    {
        [Test]
        public void UpdateValueWhen_ItemNameIsNotAgedParmigianoOrConcertTicketsOrSaffronPowderAndSellByIsGreaterThanZero_DecreaseValueofItem()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Shoe Laces", SellBy = 10, Value = 20 },
                new Item { Name = "Saffron Powder", SellBy = 0, Value = 11 },
                new Item { Name = "Concert tickets to Talkins Festival", SellBy = 9, Value = 10 },
                new Item { Name = "Concert tickets to Talkins Festival", SellBy = 4, Value = 10 },
                new Item { Name = "Aged Parmigiano", SellBy = 10, Value = 20 },
                new Item { Name = "Refrigerated milk", SellBy = 10, Value = 20 },
                new Item { Name = "Refrigerated milk", SellBy = -3, Value = 20 }};

             var app = new ViksWaresService(Items);
             var item0 = Items[0];
             var item1 = Items[1];
             var item2 = Items[2];
             var item3 = Items[3];
             var item4 = Items[4];
             var item5 = Items[5];
             var item6 = Items[6];

             var itemResult0 = new Item() {Name = "Shoe Laces", SellBy = 10, Value = 19};
             var itemResult1 = new Item() {Name = "Shoe Laces", SellBy = 9, Value = 19};
             var itemResult2 = new Item() {Name = "Saffron Powder", SellBy = 0, Value = 11};
             var itemResult3 = new Item() {Name = "Concert tickets to Talkins Festival", SellBy = 9, Value = 12};
             var itemResult4 = new Item() {Name = "Concert tickets to Talkins Festival", SellBy = 4, Value = 13 };
             var itemResult5 = new Item() {Name = "Aged Parmigiano", SellBy = 10, Value = 21};
             var itemResult6 = new Item() {Name = "Refrigerated milk", SellBy = 10, Value = 18};
             var itemResult7 = new Item() {Name = "Refrigerated milk", SellBy = -3, Value = 16};
             var itemResult8 = new Item() {Name = "Shoe Laces", SellBy = 10, Value = 19};

             //Act + Assert
            app.UpdateValue();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(itemResult0.Value,item0.Value);
                Assert.AreEqual(itemResult1.Value,item0.Value);
                Assert.AreEqual(itemResult2.Value, item1.Value);
                Assert.AreEqual(itemResult3.Value, item2.Value);
                Assert.AreEqual(itemResult4.Value,item3.Value);
                Assert.AreEqual(itemResult5.Value,item4.Value);
                Assert.AreEqual(itemResult6.Value, item5.Value);
                Assert.AreEqual(itemResult7.Value,item6.Value);
            });
        }


        [Test]
        public void UpdateItem_ForShoeLaces_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item {Name = "Shoe Laces", SellBy = 10, Value = 20}
            };

            var expectedResult = new Item
            {
                Name = "Shoe Laces",
                SellBy = 9,
                Value = 19
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult.Value, items[0].Value);
            Assert.AreEqual(expectedResult.Name, items[0].Name);
            Assert.AreEqual(expectedResult.SellBy, items[0].SellBy);
        }


        [Test]
        public void UpdateItem_AgedParmigiano_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item {Name = "Aged Parmigiano", SellBy = 2, Value = 0}
            };

            var expectedResult = new Item
            {
                Name = "Aged Parmigiano",
                SellBy = 1,
                Value = 1
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult.Value, items[0].Value);
            Assert.AreEqual(expectedResult.Name, items[0].Name);
            Assert.AreEqual(expectedResult.SellBy, items[0].SellBy);
        }

        [Test]
        public void UpdateItem_BookOfResolutions_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item{
                    Name = "Book of Resolutions",
                    SellBy = 5,
                    Value = 7
                }
            };

            var expectedResult = new Item
            {
                Name = "Book of Resolutions",
                SellBy = 4,
                Value = 6
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult.Value, items[0].Value);
            Assert.AreEqual(expectedResult.Name, items[0].Name);
            Assert.AreEqual(expectedResult.SellBy, items[0].SellBy);
        }

        [Test]
        public void UpdateItem_SaffronPowder_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 0,
                    Value = 40
                },
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 0,
                    Value = 40
                }
            };

            var expectedResult = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 0,
                    Value = 40
                },
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 0,
                    Value = 40
                }
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult[0].Name, items[0].Name);
            Assert.AreEqual(expectedResult[0].Value, items[0].Value);
            Assert.AreEqual(expectedResult[0].SellBy, items[0].SellBy);
            Assert.AreEqual(expectedResult[1].Name, items[1].Name);
            Assert.AreEqual(expectedResult[1].Value, items[1].Value);
            Assert.AreEqual(expectedResult[1].SellBy, items[1].SellBy);
        }

        [Test]
        public void UpdateItem_ConcertTicketsToTalkinsFestival_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 15,
                    Value = 20
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 11,
                    Value = 20
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 6,
                    Value = 10
                }
            };

            var expectedResult = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 14,
                    Value = 21
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 10,
                    Value = 21
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 5,
                    Value = 12
                }
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult[0].Value, items[0].Value);
            Assert.AreEqual(expectedResult[0].Name, items[0].Name);
            Assert.AreEqual(expectedResult[0].SellBy, items[0].SellBy);
            Assert.AreEqual(expectedResult[1].Value, items[1].Value);
            Assert.AreEqual(expectedResult[1].Name, items[1].Name);
            Assert.AreEqual(expectedResult[1].SellBy, items[1].SellBy);
            Assert.AreEqual(expectedResult[2].Value, items[2].Value);
            Assert.AreEqual(expectedResult[2].Name, items[2].Name);
            Assert.AreEqual(expectedResult[2].SellBy, items[2].SellBy);
        }

        [Test]
        public void UpdateItem_RefrigeratedMilk_ProducesCorrectAnswer()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated milk",
                    SellBy = 3,
                    Value = 6
                },
                new Item
                {
                    Name = "Refrigerated milk",
                    SellBy = 3,
                    Value = 26
                }
            };

            var expectedResult = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated milk",
                    SellBy = 2,
                    Value = 4
                },
                new Item
                {
                    Name = "Refrigerated milk",
                    SellBy = 2,
                    Value = 24
                }
            };

            var sut = new ViksWaresService(items);

            // Act
            sut.UpdateValue();

            // Assert
            Assert.AreEqual(expectedResult[0].Name, items[0].Name);
            Assert.AreEqual(expectedResult[0].Value, items[0].Value);
            Assert.AreEqual(expectedResult[0].SellBy, items[0].SellBy);
            Assert.AreEqual(expectedResult[1].Name, items[1].Name);
            Assert.AreEqual(expectedResult[1].Value, items[1].Value);
            Assert.AreEqual(expectedResult[1].SellBy, items[1].SellBy);
        }
    }
}