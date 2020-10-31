using OnlineStore.Extensions;
using OnlineStore.TestDataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver; 

        [FindsBy(How = How.Id, Using = "userName")]
        [CacheLookup]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement SignInButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public LoginPage()
        {

        }

        public void LoginToApplication(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);

            ElementExtension.InputText(Username, userData.Username);
            ElementExtension.InputText(Password, userData.Password);
            ElementExtension.ClickOnElement(SignInButton);
        }
    }
}
