using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.Abstract
{
    public abstract class Control : PageObject
    {
        private IWebElement NameElement => SearchContext.FindElement(By.TagName("label"));

        public Control(IWebElement webElement) : base(webElement)
        {
        }

        public string Name => NameElement.Text.Replace("*", "").Trim();

        public abstract void SetData(string data);

        public abstract string ActualData { get; }
    }
}
