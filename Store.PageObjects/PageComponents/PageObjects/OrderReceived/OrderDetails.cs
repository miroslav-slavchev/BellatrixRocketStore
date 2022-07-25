using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.OrderReceived
{
    public class OrderDetails : PageObject
    {
        private IWebElement ProductElement => SearchContext.FindElement(By.CssSelector("tbody td[class*='name']"));
        private IWebElement TotalElement => SearchContext.FindElement(By.CssSelector("tbody td[class*='total']"));
        private List<IWebElement> Rows => SearchContext.FindElements(By.CssSelector("tfoot tr")).ToList();

        public OrderDetails(IWebElement webElement) : base(webElement)
        {
        }

        public string Product => ProductElement.Text;

        public string Total => TotalElement.Text;

        public Dictionary<string, string> Details
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach(var row in Rows)
                {
                    string field = row.FindElement(By.TagName("th")).Text;
                    string value = row.FindElement(By.TagName("td")).Text;
                    result.Add(field, value);
                }
                result.Add("Product", Product);
                result.Add("Total", Total);
                return result;
            }
        }
    }
}
