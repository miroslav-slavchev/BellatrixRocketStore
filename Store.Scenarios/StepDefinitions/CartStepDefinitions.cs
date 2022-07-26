using BoDi;
using NUnit.Framework;
using Store.Scenarios.Hooks;
using System;
using TechTalk.SpecFlow;

namespace Store.Scenarios.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions : BaseTests
    {
        private Table _billingDetails;

        [When(@"Add to cart button is clicked for (.*) in stock item")]
        public void WhenAddToCartButtonIsClickedForItemInStockItem(string itemName)
        {
            App.ShopPage.Items.GetInStockShopItem(itemName).AddToCart();
        }

        [When(@"View cart button is clicked for (.*) in stock item")]
        public void WhenViewCartButtonIsClickedForItemInStockItem(string itemName)
        {
            App.ShopPage.Items.GetInStockShopItem(itemName).ViewCart();
        }

        [When(@"Proceed to checkout button is clicked in Cart page")]
        public void WhenProceedToCheckoutButtonIsClickedInCartPage()
        {
            App.CartPage.ProceedToCheckOut();
        }

        [When(@"Billing details are entered in Checkout page")]
        public void WhenBillingDetailsAreEnteredInCheckoutPage(Table table)
        {
            _billingDetails = table;
            var data = table.Rows.First();
            foreach (var field in data.Keys)
            {
                App.CheckoutPage.GetControl(field).SetData(data[field]);
            }
        }

        [Then(@"Billing details data should be correct")]
        public void ThenBillingDetailsDataShouldBeCorrect()
        {
            var data = _billingDetails.Rows.First();
            foreach (var field in data.Keys)
            {
                var value = App.CheckoutPage.GetControl(field).ActualData;
                Assert.AreEqual(data[field], value);
            }
        }

        [When(@"(.*) payment method is selected in Checkout page")]
        public void WhenDirectBankTransferPaymentMethodIsSelectedInCartPage(string method)
        {
            App.CheckoutPage.SelectPaymentMethod(method);
        }

        [When(@"Place Order button is clicked in Checkout page")]
        public void WhenPlaceOrderButtonIsClickedInCartPage()
        {
            App.CheckoutPage.PlaceOrder();
        }

        [Then(@"Thank you message should be displayed in Order received page")]
        public void ThenThankYouMessageShouldBeDisplayedInOrderReceivedPage(string message)
        {
            App.OrderReceivedPage.Message.Should().Be(message);
        }

        [Then(@"Order overview data should be")]
        public void ThenOrderDataMessageShouldBe(Table table)
        {
            TableRow data = table.Rows.First();
            foreach (var field in data.Keys)
            {
                string expectedValue = data[field];
                string actualValue = App.OrderReceivedPage.OrderOverview.Data[field];
                ValidateOverviewData(expectedValue, actualValue);
            }
        }

        private void ValidateOverviewData(string expectedValue, string actualValue)
        {
            if (expectedValue == "ValidInteger")
            {
                Assert.IsTrue(int.TryParse(actualValue, out _));
            }
            else if (expectedValue == "Today")
            {
                string todayDate = GetExpectedTodayDate();
                Assert.AreEqual(todayDate, actualValue);
            }
            else
            {
                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        private string GetExpectedTodayDate()
        {
            //July 6, 2022
            string todayDay = DateTime.Now.Day.ToString();
            string todayMonth = DateTime.Now.ToString("MMMM");
            string todayYear = DateTime.Now.Year.ToString();

            return todayMonth + " " + todayDay + ", " + todayYear;
        }

        [Then(@"Order details should be")]
        public void ThenOrderDetailsShouldBe(Table table)
        {
            TableRow data = table.Rows.First();
            foreach (var field in data.Keys)
            {
                string expectedValue = data[field];
                string actualValue = App.OrderReceivedPage.OrderDetails.Details[field];
                Assert.AreEqual(expectedValue, actualValue);
            }
        }
    }
}
