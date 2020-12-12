using System.Collections.Generic;
using Aquality.Selenium.Browsers;
using OpenQA.Selenium;

namespace CookiesSpecFlow.Steps
{
    public static class BrowserSteps
    {
        public static void AddCookie(string name, string value)
        {
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie(name, value));
        }

        public static bool IsCookieAdded(string name, string value)
        {
            var cookie = AqualityServices.Browser.Driver.Manage().Cookies.GetCookieNamed(name);
            return cookie.Value == value;
        }

        public static void DelCookie(string name)
        {
            AqualityServices.Browser.Driver.Manage().Cookies.DeleteCookieNamed(name);
        }

        public static bool IsCookieDeleted(string name)
        {
            var c = AqualityServices.Browser.Driver.Manage().Cookies.GetCookieNamed(name);
            if (c == null) return true;
            return false;
        }

        public static void DeleteAllCookies()
        {
            AqualityServices.Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static bool IsAllCookiesDeleted()
        {
            ICollection<Cookie> cookies = AqualityServices.Browser.Driver.Manage().Cookies.AllCookies;
            foreach (var cookie in cookies)
            {
                if (cookie.Value != null) return false;
            }
            return true;
        }
    }
}