using NUnit.Framework;
using OnlineStore.PageObjects;
using OnlineStore.WrapperFactory;
using OpenQA.Selenium;
using System.Configuration;

namespace OnlineStore
{
    /// <summary>
    /// Test whether system is able to log in successfully
    /// </summary>
    public class LoginTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser("Chrome");
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
        }

        [Test]
        public void TestLogin()
        {
            Page.Login.LoginToApplication("LoginTest");
        }
    }
}
