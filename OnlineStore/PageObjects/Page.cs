using OnlineStore.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.PageObjects
{
    static class Page
    {
        private static T GetPage<T>() where T: new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page; 
        }

        public static LoginPage Login
        {
            get
            {
                return GetPage<LoginPage>(); 
            }
        }

        public static ProfilePage Profile
        {
            get
            {
                return GetPage<ProfilePage>();
            }
        }
    }
}
