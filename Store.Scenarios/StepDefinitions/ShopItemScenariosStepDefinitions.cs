using BoDi;
using NUnit.Framework;
using Store.Application;
using Store.Library;
using Store.Library.PageComponents.PageObjects.ShopItems;
using Store.Scenarios.Hooks;
using System;
using TechTalk.SpecFlow;

namespace Store.Scenarios.StepDefinitions
{
    [Binding]
    public class ShopItemScenariosStepDefinitions : BaseTest
    {
        public ShopItemScenariosStepDefinitions(App app, Dictionary<string, dynamic> testData) : base(app, testData)
        {
        }

        [Given(@"Store Home page is loaded")]
        public void GivenStoreHomePageIsLoaded()
        {
            App.Navigation.OpenHomePage();
        }

        [When(@"(.*) sort order is applied")]
        public void WhenSortOrderIsApplied(string sortOrder)
        {
            App.ShopPage.SetSort(sortOrder);
        }

        [Then(@"(.*) shop items must be shown")]
        public void ThenShopItemsMustBeShown(int count)
        {
            App.ShopPage.Items.AllShopItems.Count.Should().Be(count);
        }

        [Then(@"The items data should be")]
        public void ThenTheItemsDataShouldBe(Table table)
        {
            for (int i = 0; i < table.Rows.Count;i++)
            {
                var row = table.Rows[i];
                var item = App.ShopPage.Items.AllShopItems.ElementAt(i);
                ValidateItem(item, row);
            }
        }

        private void ValidateItem(ShopItem item, TableRow row)
        {
            Assert.AreEqual(row["Name"], item.Name);
            Assert.AreEqual(bool.Parse(row["On Sale"]), item.HasSaleLabel);
            Assert.AreEqual(double.Parse(row["Original Price"]), item.OriginalPrice);
            Assert.AreEqual(double.Parse(row["Current Price"]), item.CurrentPrice);
        }

        [When(@"(.*) Shop item is opened")]
        public void WhenShopItemIsOpened(string itemName)
        {
            App.ShopPage.Items.GetShopItem(itemName).Open();
        }

        [Then(@"The item must be on sale")]
        public void ThenTheItemMustBeOnSale()
        {
            App.ShopItemPage.Product.HasSaleLabel.Should().BeTrue();
        }

        [When(@"Read More Button is clicked for (.*) out of stock item")]
        public void WhenReadMoreButtonIsClickedForOutOfStockItem(string itemName)
        {
            var item = App.ShopPage.Items.GetOutOfStockShopItem(itemName);
            item.ReadMore();
        }

        [Then(@"Shop item data should be")]
        public void ThenShopItemDataShouldBe(Table table)
        {
            var keys = table.Rows.First().Keys;
            foreach (var field in keys)
            {
                var value = table.Rows.First()[field];
                ValidateField(field, value);
            }
        }


        [Then(@"Shop item (.*) value should be '(.*)'")]
        public void ThenShopItemCategoryValueShouldBe(string field, object expectedValue)
        {
            ValidateField(field, expectedValue);
        }

        private void ValidateField(string field, object expectedValue)
        {
            object actualValue;
            switch (field)
            {
                case "Name": expectedValue = expectedValue.ToString(); actualValue = App.ShopItemPage.Product.Name; break;
                case "Sale": expectedValue = bool.Parse(expectedValue.ToString()); actualValue = App.ShopItemPage.Product.HasSaleLabel; break;
                case "Original Price": expectedValue = double.Parse(expectedValue.ToString()); actualValue = App.ShopItemPage.Product.OriginalPrice; break;
                case "Current Price": expectedValue = double.Parse(expectedValue.ToString()); actualValue = App.ShopItemPage.Product.CurrentPrice; break;
                case "Out of Stock": expectedValue = bool.Parse(expectedValue.ToString()); actualValue = App.ShopItemPage.Product.OutOfStock; break;
                case "Category": expectedValue = expectedValue.ToString(); actualValue = App.ShopItemPage.Product.Category; break;
                case "Description": expectedValue = expectedValue.ToString(); actualValue = App.ShopItemPage.Product.Description; break;
                default: throw new NotSupportedException("Field not supported:" + field);
            }

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
