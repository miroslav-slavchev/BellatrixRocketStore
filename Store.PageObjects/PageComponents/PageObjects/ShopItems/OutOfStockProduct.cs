using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public class OutOfStockProduct : Product
    {
        private IWebElement OutOfStockLabelElement => SearchContext.FindElement(By.ClassName("out-of-stock"));

        public OutOfStockProduct(IWebElement webElement) : base(webElement)
        {
        }

        public string OutOfStockLabel => OutOfStockLabelElement.Text;
    }
}
