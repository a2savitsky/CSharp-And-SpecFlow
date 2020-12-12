using TechTalk.SpecFlow;
using BasicAuthorizationSpecFlowProject.Forms;
using NUnit.Framework;
using Aquality.Selenium.Browsers;
using extension.StringUtils;

namespace BasicAuthorizationSpecFlowProject.Steps
{
    [Binding]
    public class BasicAuthorizationSteps
    {
        private MainPage mainPage;

        private readonly string expTitle = "{\r\n  \"authenticated\": true, \r\n  \"user\": \"user\"\r\n}";

        public BasicAuthorizationSteps()
        {
            mainPage = new MainPage();
        }

        [When(@"I go to url with (.*) and (.*)")]
        public void WhenIGoToUrlWithAnd(string user, string password)
        {
            AqualityServices.Browser.GoTo(Url.GetUrlForBasicAuthorization(user, password));
        }

        [Then(@"Main page is open")]
        public void ThenMainPageIsOpen()
        {
            Assert.AreEqual(mainPage.GetTextFromTitlePage(), expTitle, "Main page is not open");
        }
    }
}