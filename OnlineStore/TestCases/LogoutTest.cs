using NUnit.Framework;
using OnlineStore.PageObjects;
using OnlineStore.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.TestCases
{
    /// <summary>
    /// This test has been used to validate if Log out function is working properly
    /// </summary>
    [TestFixture]
    class LogoutTest
    {
        [SetUp]
        public void Initialize()
        {
            BrowserFactory.InitBrowser("Chrome");
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]); 
        }

        [Test]
        public void LogoutInInProfilePage()
        {
            Page.Login.LoginToApplication("LogoutTest");
            Page.Profile.Logout();
        }

    }
}
