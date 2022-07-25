using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public abstract class BellatrixProduct : PageObject
    {
        protected abstract IWebElement NameElement { get; }
        private IReadOnlyCollection<IWebElement> SaleElement => SearchContext.FindElements(By.ClassName("onsale"));
        private IWebElement OriginalPriceElement => SearchContext.FindElement(By.CssSelector("del bdi"));
        private IWebElement CurrentPriceElement => SearchContext.FindElement(By.CssSelector("ins bdi"));
        private IWebElement CurrencySymbolElement => SearchContext.FindElement(By.ClassName("woocommerce-Price-currencySymbol"));

        protected BellatrixProduct(IWebElement webElement) : base(webElement)
        {

        }

        public bool HasSaleLabel => SaleElement.Count > 0;

        public string CurrencySymbol => CurrencySymbolElement.Text;

        public string Name => NameElement.Text;

        public double OriginalPrice => GetPrice(OriginalPriceElement);

        public double CurrentPrice => GetPrice(CurrentPriceElement);
        protected double GetPrice(IWebElement element)
        {
            StringBuilder text = new StringBuilder(element.Text);
            text.Remove(text.Length - 1, 1);
            text.Replace(",", "");
            double price = double.Parse(text.ToString());
            return price;
        }
    }
}
