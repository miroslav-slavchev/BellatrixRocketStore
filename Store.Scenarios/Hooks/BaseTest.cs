using Store.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Scenarios.Hooks
{
    [Binding]
    public class BaseTest
    {
        protected App App { get; set; }
        protected Dictionary<string, dynamic> TestData { get; set; }

        public BaseTest(App app, Dictionary<string, dynamic> testData)
        {
            App = app;
            TestData = testData;
        }
    }
}
