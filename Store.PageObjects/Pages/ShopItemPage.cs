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
        private List<IWebElement> UpsellsElement => Body.FindElements(By.CssSelector("section.upsells")).ToList();
        private List<IWebElement> RelatedProductsElement => Body.FindElements(By.CssSelector("related.products")).ToList();

        private List<IWebElement> InStockProductElement => Body.FindElements(By.CssSelector("div + .product.instock")).ToList();
        private List<IWebElement> OutOfStockProductElement => Body.FindElements(By.CssSelector("div + .product.outofstock")).ToList();

        public ShopItemPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public Product Product => InStockProductElement.Count() > 0 ? new InStockProduct(InStockProductElement.First()) : new OutOfStockProduct(OutOfStockProductElement.First());

        public InStockProduct? TryGetInStockProduct() => Product is InStockProduct ? (InStockProduct)Product : null;

        public OutOfStockProduct? TryGetOutOfStockProduct() => Product is OutOfStockProduct ? (OutOfStockProduct)Product : null;

        public ItemsSection? TryGetRelatedItems() => UpsellsElement.Count() > 0 ? new ItemsSection(UpsellsElement.First()) : null;

        public ItemsSection? TryGetYouMayAlsoLike() => RelatedProductsElement.Count() > 0 ? new ItemsSection(RelatedProductsElement.First()) : null;
    }
}
