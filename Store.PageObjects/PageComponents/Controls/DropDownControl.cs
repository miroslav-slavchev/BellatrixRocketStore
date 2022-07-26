using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.PageComponents.Controls
{
    public class DropDownControl : Control
    {
        private IWebElement SelectExpand => SearchContext.FindElement(By.CssSelector("[id*='select2-billing_'][id$='-container']"));

        public DropDownControl(IWebElement webElement) : base(webElement)
        {
        }

        public override string ActualData => SelectExpand.Text;

        public override void SetData(string data)
        {
            SelectExpand.Click();

            List<IWebElement> items = WrappedDriver.FindElements(By.CssSelector("ul.select2-results__options li")).ToList();
            IWebElement item = items.Where(item => item.Text == data).First();
            item.Click();
            WaitLoadingIndicatorToDissappear();
        }
    }
}
