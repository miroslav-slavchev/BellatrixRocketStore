using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;

namespace Store.Library.PageComponents.PageObjects.ShopItems
{
    public class ItemsSection : PageObject
    {
        private List<IWebElement> ShopItemElements => SearchContext.FindElements(By.CssSelector("li.product")).ToList();

        private List<IWebElement> InStockShopItemElements => SearchContext.FindElements(By.CssSelector("li.product.instock, li.product.onbackorder ")).ToList();
        private List<IWebElement> OutOfStockShopItemElements => SearchContext.FindElements(By.CssSelector("li.product.outofstock")).ToList();

        public ItemsSection(IWebElement webElement) : base(webElement)
        {
        }

        public List<InStockShopItem> InStockShopItems => InStockShopItemElements.Select(item => new InStockShopItem(item)).ToList();

        public InStockShopItem GetInStockShopItem(string name) => InStockShopItems.Where(item => item.Name == name).Single();

        public List<OutOfStockShopItem> OutOfStockShopItems => OutOfStockShopItemElements.Select(item => new OutOfStockShopItem(item)).ToList();

        public OutOfStockShopItem GetOutOfStockShopItem(string name) => OutOfStockShopItems.Where(item => item.Name == name).Single();

        public List<ShopItem> AllShopItems
        {
            get
            {
                List<ShopItem> allShopItems = new();

                foreach (var element in ShopItemElements)
                {
                    if (element.GetAttribute("class").Contains("outofstock"))
                    {
                        allShopItems.Add(new OutOfStockShopItem(element));
                    }
                    else
                    {
                        allShopItems.Add(new InStockShopItem(element));
                    }
                }

                return allShopItems;
            }
        }

        public ShopItem GetShopItem(string name) => AllShopItems.Where(item => item.Name == name).Single();
    }
}
