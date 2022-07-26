using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public class InStockProduct : Product, IAddToCart
    {
        private IWebElement AddToCartButton => SearchContext.FindElement(By.ClassName("add-to-cart"));
        private IWebElement NumberINput => SearchContext.FindElement(By.CssSelector("input[name='quantity']"));

        public InStockProduct(IWebElement webElement) : base(webElement)
        {
        }

        public void AddToCart()
        {
            AddToCartButton.Click();
        }

        public void SetQuantity(int number)
        {
            NumberINput.SendKeys(number.ToString());
        }
    }
}
