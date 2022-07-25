using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;

namespace Store.Library.PageComponents.Controls
{
    internal class TextInputControl : Control
    {
        private IWebElement Input => SearchContext.FindElement(By.TagName("input"));

        public TextInputControl(IWebElement webElement) : base(webElement)
        {
        }

        public override string ActualData => Input.GetAttribute("value");

        public override void SetData(string data)
        {
            Input.Clear();
            Input.SendKeys(data);
        }
    }
}
