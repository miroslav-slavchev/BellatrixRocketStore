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
    public class MainHooks
    {
        private IObjectContainer ObjectContainer { get; set; }
        protected DriverManager DriverManager { get; set; }

        public MainHooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeScenario(Order = 1)]
        public void StartBrowser()
        {
            DriverManager = new DriverManager();
            DriverManager.Start();
            ObjectContainer.RegisterInstanceAs(DriverManager);
        }

        [BeforeScenario(Order = 2)]
        public void InitObjects()
        {
            App app = new(DriverManager.Driver);
            ObjectContainer.RegisterInstanceAs(app);
            Dictionary<string, dynamic> testData = new();
            ObjectContainer.RegisterInstanceAs(testData);
        }

        [AfterScenario]
        public void StopBrowser()
        {
            DriverManager.Quit();
        }

    }
}
