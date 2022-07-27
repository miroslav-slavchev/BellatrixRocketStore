using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class Navigation : PageObject
    {
        public Navigation(IWebElement webElement) : base(webElement)
        {
        }

        public Shop OpenHomePage()
        {
            Navigate(@"Home");
            return new Shop(WrappedDriver);
        }

        public CartPage OpenCartPage()
        {
            Navigate(@"Cart");
            return new CartPage(WrappedDriver);
        }

        public CheckoutPage OpenCheckoutPage()
        {
            Navigate(@"Checkout");
            return new CheckoutPage(WrappedDriver);
        }

        private void Navigate(string locatorSuffix)
        {
            IWebElement webElement = SearchContext.FindElement(By.PartialLinkText(locatorSuffix));
            string name = webElement.Text;
            if (CurrentPageName != name)
            {
                Redirect(webElement);
            }
        }

        public string CurrentPageName => SearchContext.FindElement(By.CssSelector("li.current_page_item")).Text;
    }
}
