using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Store.PageObjects.Wait;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public class InStockShopItem : ShopItem
    {
        private IWebElement AddToCartElement => SearchContext.FindElement(By.CssSelector("a[href*='add-to-cart']"));
        private IWebElement ViewCartElement => SearchContext.FindElement(By.CssSelector("a[title='View cart']"));
        
        public InStockShopItem(IWebElement webElement) : base(webElement)
        {
        }

        public void AddToCart()
        {
            AddToCartElement.Click();
            Wait(3).Until(Conditions.ElementAttributeContain(AddToCartElement, "class", "added"));
        }

        public void ViewCart() => Redirect(ViewCartElement);
    }
}
