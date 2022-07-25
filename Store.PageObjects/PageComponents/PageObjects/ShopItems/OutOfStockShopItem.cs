using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public class OutOfStockShopItem : ShopItem
    {
        private IWebElement ReadMoreElement => SearchContext.FindElement(By.CssSelector("a.button"));

        public OutOfStockShopItem(IWebElement webElement) : base(webElement)
        {
        }

        public void ReadMore() => Redirect(ReadMoreElement);
    }
}
