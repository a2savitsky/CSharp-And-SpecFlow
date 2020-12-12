using TechTalk.SpecFlow;
using CookiesSpecFlow.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

namespace CookiesSpecFlow.Steps
{
    [Binding]
    public class CookiesSteps
    {
        private MainPage mainPage;

        public CookiesSteps()
        {
            mainPage = new MainPage();
        }

        [Given(@"Site example\.com")]
        public void GivenSiteExample_Com()
        {
            Assert.True(mainPage.State.WaitForDisplayed(), "Main page is not open");
        }

        [When(@"I add cookies")]
        public void WhenIAddCookies(Table table)
        {
            var cookies = table.CreateSet<Cookie>();
            foreach (var cookie in cookies)
            {
                BrowserSteps.AddCookie(cookie.Name, cookie.Value);
            }
        }

        [Then(@"Cookies are added")]
        public void ThenCookiesAreAdded(Table table)
        {
            var cookies = table.CreateSet<Cookie>();
            foreach (var cookie in cookies)
            {
                Assert.True(BrowserSteps.IsCookieAdded(cookie.Name, cookie.Value), $"Cookies {cookie.Name} are not added");
            }
        }

        [When(@"I delete cookie with name '(.*)'")]
        public void WhenIDeleteCookieWithName(string name)
        {
            BrowserSteps.DelCookie(name);
        }

        [Then(@"Cookie with name '(.*)' is deleted")]
        public void ThenCookieWithNameIsDeleted(string name)
        {
            Assert.True(BrowserSteps.IsCookieDeleted(name), $"Cookie with name {name} is not deleted");
        }

        [When(@"I change value of cookie '(.*)' on '(.*)'")]
        public void WhenIChangeValueOfCookieOn(string name, string value)
        {
            BrowserSteps.AddCookie(name, value);
        }

        [Then(@"Cookie with name '(.*)' has new value '(.*)'")]
        public void ThenCookieWithNameHasNewValue(string name, string value)
        {
            Assert.True(BrowserSteps.IsCookieAdded(name, value), $"Value of cookie named {name} is not changed");
        }

        [When(@"I delete all cookies")]
        public void WhenIDeleteAllCookies()
        {
            BrowserSteps.DeleteAllCookies();
        }

        [Then(@"All cookies are deleted")]
        public void ThenAllCookiesAreDeleted()
        {
            Assert.True(BrowserSteps.IsAllCookiesDeleted());
        }
    }
}