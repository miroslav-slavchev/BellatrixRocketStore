using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Store.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Library;
using BoDi;

namespace Store.Scenarios.Hooks
{
    [Binding]
    public class BaseTests
    {
        protected DriverManager DriverManager { get; set; }
        protected App App { get; set; }

        [BeforeScenario(Order = 1)]
        public void StartBrowser()
        {
            DriverManager = new DriverManager();
            DriverManager.Start();
            App = new(DriverManager.Driver);
        }

        [AfterScenario]
        public void StopBrowser()
        {
            DriverManager.Quit();
        }

    }
}
