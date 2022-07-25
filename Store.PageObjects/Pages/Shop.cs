using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Store.Library.PageComponents.Abstract;
using Store.Library.PageComponents.PageObjects.ShopItems;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class Shop : Page
    {
        private IWebElement TitleElement => Body.FindElement(By.TagName("h1"));
        private IWebElement SelectSort => Body.FindElement(By.CssSelector("select.orderby"));


        private List<IWebElement> ShopItemElements => Body.FindElements(By.CssSelector("li.product")).ToList();
        private List<IWebElement> InStockShopItemElements => Body.FindElements(By.CssSelector("li.product.instock, li.product.onbackorder ")).ToList();
        private List<IWebElement> OutOfStockShopItemElements => Body.FindElements(By.CssSelector("li.product.outofstock")).ToList();

        public Shop(IWebDriver driver) : base(driver)
        {
        }

        public string Title => TitleElement.Text;

        public void SetSort(string option)
        {
            SelectElement selectElement = new SelectElement(SelectSort);
            string value = selectElement.Options.Single(optionElement => optionElement.Text == option).GetAttribute("value");
            selectElement.SelectByText(option);
            Wait(10).Until(ExpectedConditions.UrlContains(value));
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
