using TechTalk.SpecFlow;
using NUnit.Framework;
using OnlinerSpecFlow.Forms;
using OnlinerSpecFlow.Models;

namespace OnlinerSpecFlow.Steps
{
    [Binding]
    public class TestingOnlinerSteps
    {
        private MainPage mainPage;
        
        private CategoryPage categoryPage;
        
        private LoginForm loginForm;
        
        private CatalogPage catalogPage;

        private ScenarioContext context;
        
        public TestingOnlinerSteps(ScenarioContext context)
        {
            this.context = context;
            mainPage = new MainPage();
            categoryPage = new CategoryPage();
            loginForm = new LoginForm();
            catalogPage = new CatalogPage();
        }

        [Given(@"Main page of the Onliner")]
        [Then(@"Main page is open")]
        public void ThenMainPageIsOpen()
        {
            Assert.IsTrue(mainPage.State.WaitForDisplayed(), "Main page is not open");
        }

        [When(@"I do authorization")]
        public void WhenIDoAuthorization()
        {
            mainPage.ClickOnLoginButton();
            loginForm.FillLoginFormAndClickSubmit(User.UserName, User.Password);
        }
        
        [When(@"I go to Catalog page")]
        public void WhenIGoToPage()
        {
            mainPage.ClickOnCatalogLink();
        }
        
        [When(@"I choose a random category,click on it and save its title to context as '(.*)'")]
        public void WhenIChooseARandomCategoryClickOnItAndSaveItsTitleToContextAs(string expTitle)
        {
            context[expTitle] = catalogPage.GetNameOfRandomCategoryAndClick();
        }
        
        [When(@"I do logout")]
        public void WhenIDoLogout()
        {
            mainPage.DoLogout();
        }

        [Then(@"Authorization should be done")]
        public void ThenAuthorizationShouldBeDone()
        {
            Assert.IsTrue(mainPage.IsUserLoggedIn(), "Authorization is not done");
        }
        
        [Then(@"Catalog page should be open")]
        public void ThenPageShouldBeDone()
        {
            Assert.IsTrue(catalogPage.State.WaitForDisplayed(), "Catalog page is not open");
        }

        [Then(@"Chosen category page title should be math with '(.*)'")]
        public void ThenChosenCategoryPageTitleShouldBeMathWith(string expTitle)
        {
            Assert.AreEqual(context.Get<string>(expTitle), categoryPage.GetNameOfCategory(), "Chosen category is not as expected");
        }
        
        [Then(@"Logout should be done")]
        public void ThenLogoutShouldBeDone()
        {
            Assert.IsTrue(mainPage.IsUserLoggedOut(), "User is not logged out");
        }
    }
}