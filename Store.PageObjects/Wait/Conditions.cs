using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.PageObjects.Wait
{

    public static class Conditions
    {
        public static Func<IWebDriver, bool> ElementAttributeContain(
                                             IWebElement element,
                                             string attribute,
                                             string attrbiuteValue)
        {
            return (driver) =>
            {
                try
                {
                    return element.GetAttribute(attribute).Contains(attrbiuteValue);
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementToHaveAttribute(
                                             IWebElement element,
                                             string attribute)
        {
            return (driver) =>
            {
                try
                {
                    return element.GetAttribute(attribute) != null;
                }
                catch
                {
                    return false;
                }
            };
        }
    }
}