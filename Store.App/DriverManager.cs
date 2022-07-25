using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application
{
    public class DriverManager
    {
        private static IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public void Start()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                LoadUrl();
            }
        }

        private void LoadUrl(string url = null)
        {
            if (url == null)
            {
                url = Config.Configuration.Url;
            }

            Driver.Url = url;
            Driver.Manage().Window.Maximize();
        }

        public void Quit() => Driver.Quit();
    }
}
