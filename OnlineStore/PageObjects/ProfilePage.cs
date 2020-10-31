using OnlineStore.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.PageObjects
{
    class ProfilePage
    {
        [FindsBy(How = How.Id, Using = "searchBox")]
        [CacheLookup]
        private IWebElement searchBox { get; set; } 

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Log out')]")]
        [CacheLookup]
        private IWebElement logoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "userName-value")]
        [CacheLookup]
        private IWebElement usernameTextFieldValue { get; set; }

        public void Logout()
        {
            Thread.Sleep(5000);
            ElementExtension.ClickOnElement(logoutButton);
        }
    }
}
