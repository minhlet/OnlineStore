using OnlineStore.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Extensions
{
    /// <summary>
    /// Defines WebElement Extensions for Framework
    /// </summary>
    class ElementExtension
    {
        public static void InputText(IWebElement element, string text)
        {
            if (WaitForElementToBeVisible(element))
            {
                element.Clear();
                element.SendKeys(text);
            }
        }

        public static void ClickOnElement(IWebElement element)
        {
            if (WaitForElementToBeVisible(element))
                element.Click();
        }

        public static bool WaitForElementToBeVisible(IWebElement element)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromSeconds(250);
            wait.PollingInterval = TimeSpan.FromSeconds(5);

            Func<IWebElement, bool> isElementToBeVisible = new Func<IWebElement, bool>(ele => {
                if (ele.Enabled && ele.Displayed)
                    return true;
                else
                    return false; 
            });
            bool isElementPresent = wait.Until(isElementToBeVisible);
            return isElementPresent;
        }
    }
}
