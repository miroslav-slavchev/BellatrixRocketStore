using OpenQA.Selenium;
using Store.Library.PageComponents.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Library.Pages
{
    public class CartPage : Page
    {
        private IWebElement ProceedToCheckoutButton => Body.FindElement(By.ClassName("checkout-button"));

        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void ProceedToCheckOut() => Redirect(ProceedToCheckoutButton);
    
    }
}
