using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace OnlinerSpecFlow.Forms
{
    public class MainPage : Form
    {
        private IButton LoginButton => ElementFactory.GetButton(By.XPath("//div[@id='userbar']//div[contains(@class, 'item--text')]"), "Login button"); protected ILabel UserAvatarLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'user-avatar')]"), "User avatar label");
        
        private ILink CatalogLink => ElementFactory.GetLink(By.XPath("//a[@href='https://catalog.onliner.by/']"), "Catalog link");
        
        private IButton LogoutButton => ElementFactory.GetButton(By.XPath("//div[contains(@class, 'logout')]//a[contains(@data-bind, 'logout')]"), "Logout button");
        
        public MainPage() : base(By.XPath("//div[@class='b-tiles-outer']"), "Main page")
        {
        }
        
        public void ClickOnLoginButton()
        {
            LoginButton.ClickAndWait();
        }
        
        public void ClickOnCatalogLink()
        {
            CatalogLink.ClickAndWait();
        }

        public bool IsUserLoggedIn()
        {
            return UserAvatarLabel.State.WaitForDisplayed();
        }

        public void DoLogout()
        {
            UserAvatarLabel.Click();
            LogoutButton.ClickAndWait();
        }
        
        public bool IsUserLoggedOut()
        {
            return LoginButton.State.WaitForDisplayed();
        }
    }
}