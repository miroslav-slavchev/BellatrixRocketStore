using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Store.PageObjects.Wait;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.Abstract
{
    public abstract class Page 
    {
        protected IWebDriver WrappedDriver { get; private set; }
        protected IWebElement Body => WrappedDriver.FindElement(By.TagName("body"));

        public Page(IWebDriver webDriver) 
        {
            WrappedDriver = webDriver;
        }

        protected WebDriverWait Wait(int timeOutInSeconds) => new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(timeOutInSeconds));

        protected void Redirect(IWebElement redirect)
        {
            string newUrl = redirect.GetAttribute("href");
            redirect.Click();
            Wait(10).Until(ExpectedConditions.UrlToBe(newUrl));
        }

        protected void WaitLoadingIndicatorToDissappear()
        {
            IWebElement loading = Wait(7).Until(ExpectedConditions.ElementExists(By.ClassName("blockUI")));
            Wait(5).Until(ExpectedConditions.StalenessOf(loading));
        }
    }
}
