using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using Store.Library.PageComponents.PageObjects.OrderReceived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class OrderReceivedPage : Page
    {
        private IWebElement MessageElement => base.Body.FindElement(By.CssSelector("p.woocommerce-notice"));
        private IWebElement OrderOverviewElement => Body.FindElement(By.CssSelector("ul[class*='order-overview']"));
        private IWebElement OrderDetailsElement => Body.FindElement(By.CssSelector("section.woocommerce-order-details"));

        public OrderReceivedPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public string Message => MessageElement.Text;

        public OrderOverview OrderOverview => new OrderOverview(OrderOverviewElement);

        public OrderDetails OrderDetails => new OrderDetails(OrderDetailsElement);
    }
}
