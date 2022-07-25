using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Store.Library.PageComponents.Abstract;
using Store.Library.PageComponents.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class CheckoutPage : Page
    {
        private IWebElement PlaceOrderButton => Body.FindElement(By.Id("place_order"));
        private List<IWebElement> ControlElements => Body.FindElements(By.CssSelector("div.woocommerce-billing-fields p.form-row")).ToList();

        public CheckoutPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public Control GetControl(string name) => Controls.Single(control => control.Name == name);

        private List<Control> Controls
        {
            get
            {
                List<Control> controls = new();
                foreach (var element in ControlElements)
                {
                    if (HasTextInput(element))
                    {
                        controls.Add(new TextInputControl(element));
                    }
                    else if (HasSelect(element))
                    {
                        controls.Add(new DropDownControl(element));
                    }
                    else
                    {
                        throw new NotSupportedException("Unspported control!");
                    }
                }
                return controls;
            }
        }

        private bool HasTextInput(IWebElement element) => element.FindElements(By.CssSelector("input[class*='input-text']")).Count > 0;
        private bool HasSelect(IWebElement element) => element.FindElements(By.CssSelector("span[class*='select2-container']")).Count > 0;

        public void PlaceOrder()
        {
            PlaceOrderButton.Click();
            WaitLoadingIndicatorToDissappear();
        }

        public void SelectPaymentMethod(string method)
        {
            var button = GetPaymentRadioButton(method);
            button.Click();
            //WaitLoadingIndicatorToDissappear();
        }

        private IWebElement GetPaymentRadioButton(string name)
        {
            List<IWebElement> items = Body.FindElements(By.CssSelector("ul.methods label")).ToList();
            IWebElement item = items.Where(item => item.Text.Trim() == name).First();
            return item;
        }
    }
}
