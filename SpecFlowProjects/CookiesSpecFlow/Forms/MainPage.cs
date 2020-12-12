using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace CookiesSpecFlow.Forms
{
    public class MainPage : Form
    {
        public MainPage() : base(By.XPath("//h1"), "Main page")
        {
        }
    }
}