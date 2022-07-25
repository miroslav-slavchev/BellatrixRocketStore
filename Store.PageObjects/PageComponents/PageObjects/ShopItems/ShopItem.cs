using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public abstract class ShopItem : BellatrixProduct
    {
        protected override IWebElement NameElement => SearchContext.FindElement(By.CssSelector("[class*='product'][class*='title']"));
        private IWebElement RedirectElement => SearchContext.FindElement(By.CssSelector("a.woocommerce-LoopProduct-link"));

        public ShopItem(IWebElement webElement) : base(webElement)
        {
        }

        public void Open() => Redirect(RedirectElement);

    }
}
