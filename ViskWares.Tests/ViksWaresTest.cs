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
    }
}