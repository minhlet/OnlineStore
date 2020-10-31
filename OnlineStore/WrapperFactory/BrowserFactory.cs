using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OnlineStore.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public static IWebDriver Driver { get; set; }

        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    Driver = new FirefoxDriver();
                    Drivers.Add(browserName, Driver);
                    break;
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized"); 
                    Driver = new ChromeDriver(options);
                    Drivers.Add(browserName, Driver);
                    break;
            }
            
            return Driver;
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllBrowsers()
        {
            foreach(var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
