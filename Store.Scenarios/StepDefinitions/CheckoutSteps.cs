using NUnit.Framework;
using Store.Library;
using Store.Scenarios.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Scenarios.StepDefinitions
{
    public class CheckoutSteps : BaseTest
    {
        public CheckoutSteps(App app, Dictionary<string, dynamic> testData) : base(app, testData)
        {
        }


        [Then(@"Billing details data should be correct 2")]
        public void ThenBillingDetailsDataShouldBeCorrect2()
        {
            var data = ((Table)TestData["BillingDetails"]).Rows.First();
            foreach (var field in data.Keys)
            {
                var value = App.CheckoutPage.GetControl(field).ActualData;
                Assert.AreEqual(data[field], value);
            }
        }
    }
}
