using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace BasicAuthorizationSpecFlowProject.Forms
{
    public class MainPage : Form
    {
        private ILabel TitlePage => ElementFactory.GetLabel(By.XPath("//pre"), "Title of page");

        public MainPage() : base(By.XPath("//pre"), "Main page")
        {
        }

        public string GetTextFromTitlePage()
        {
            return TitlePage.Text;
        }
    }
}