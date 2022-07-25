using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using Store.Library.PageComponents.PageObjects.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class ShopItemPage : Page
    {
        private IWebElement ProductElement => Body.FindElement(By.ClassName("product"));

        public ShopItemPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public Product Product => new Product(ProductElement);
    }
}
