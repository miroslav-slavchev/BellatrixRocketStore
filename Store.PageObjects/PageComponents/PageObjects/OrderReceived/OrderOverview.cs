using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.OrderReceived
{
    public class OrderOverview : PageObject
    {
        private List<IWebElement> Elements => SearchContext.FindElements(By.CssSelector("li[class*='woocommerce-order-overview']")).ToList();

        public OrderOverview(IWebElement webElement) : base(webElement)
        {
        }

        public Dictionary<string, string > Data
        {
            get
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                foreach(var element in Elements)
                {
                    string value = element.FindElement(By.TagName("strong")).Text;
                    string field = element.Text.Replace(value, "").Trim();
                    data.Add(field, value);
                }

                return data;
            }
        }
    }
}
