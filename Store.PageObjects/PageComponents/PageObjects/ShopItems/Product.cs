using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public abstract class Product : BellatrixProduct
    {
        protected override IWebElement NameElement => SearchContext.FindElement(By.TagName("h1"));
        private IReadOnlyCollection<IWebElement> OutOfStockElement => SearchContext.FindElements(By.ClassName("out-of-stock"));
        private IWebElement DescriptionElement => SearchContext.FindElement(By.CssSelector("div.woocommerce-product-details__short-description p"));
        private IWebElement CategoryElement => SearchContext.FindElement(By.CssSelector("a[rel=tag]"));

        public Product(IWebElement webElement) : base(webElement)
        {
        }

        public string Description => DescriptionElement.Text;

        public bool OutOfStock => OutOfStockElement.Count > 0;

        public string Category => CategoryElement.Text;

        public Dictionary<string, string> AdditionalInformation { get; }

        public void OpenCategory()
        {
            CategoryElement.Click();
        }

    }
}
