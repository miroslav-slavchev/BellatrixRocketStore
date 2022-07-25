using OpenQA.Selenium;
using Store.Library.Pages;

namespace Store.Library
{
    public class App
    {
        private IWebDriver Driver { get; init; }

        public App(IWebDriver driver)
        {
            Driver = driver;
            ShopPage = new(Driver);
            ShopItemPage = new(Driver);
            OrderReceivedPage = new(Driver);
            CartPage = new(Driver);
            CheckoutPage = new(Driver);
        }

        public Shop ShopPage { get; init; }

        public ShopItemPage ShopItemPage { get; init; }

        public OrderReceivedPage OrderReceivedPage { get; init; }

        public CartPage CartPage { get; init; }

        public CheckoutPage CheckoutPage { get; init; }
    }
}
