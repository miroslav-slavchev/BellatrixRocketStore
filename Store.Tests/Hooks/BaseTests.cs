using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Hooks
{
    public class BaseTests
    {
        private const string Url = @"http://demos.bellatrix.solutions/";
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public void StartBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Url = Url;
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void StopBrowser()
        {
            Driver.Quit();
        }
    }
}
