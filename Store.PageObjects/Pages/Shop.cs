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

        private IWebElement ItemsSectionElement => Body.FindElement(By.CssSelector("ul.products"));
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

        public ItemsSection Items => new ItemsSection(ItemsSectionElement);
    }
}
