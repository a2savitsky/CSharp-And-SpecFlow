using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace IFrameSpecFlow.Forms
{
    public class MainPage : Form
    {
        private IButton AlertConfButton => ElementFactory.GetButton(By.XPath("//div[@role='alertdialog']//button[@role='presentation']"), "Alert confirm button");

        private string frameId = "mce_0_ifr";

        private ILabel TitlePage => ElementFactory.GetLabel(By.XPath("//h3"), "Title of page");

        private ITextBox TextBoxInFrame => ElementFactory.GetTextBox(By.XPath("//p"), "Text box in frame");

        private ITextBox BoldedTextBoxInFrame => ElementFactory.GetTextBox(By.XPath("//p/strong"), "Bolded text box in frame");

        private IButton HighlightTextButton => ElementFactory.GetButton(By.XPath("//div[@data-index='0']"), "Highlight text button");

        private IButton MakeBoldButton => ElementFactory.GetButton(By.XPath("//button[@aria-label='Bold']"), "Make bold text button");

        public MainPage() : base(By.XPath("//h3"), "Main page")
        {
        }

        public void ConfirmAler()
        {
            AlertConfButton.State.WaitForClickable();
            AlertConfButton.ClickAndWait();
        }

        public string GetTextFromTitle()
        {
            return TitlePage.Text;
        }

        public void InputTextInFrame(string text)
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(frameId);
            TextBoxInFrame.ClearAndType(text);
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
        }

        public string GetTextFromIFrameField()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(frameId);
            string text = TextBoxInFrame.Text;
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
            return text;
        }

        public void HighlightTextInFrame()
        {
            HighlightTextButton.Click();
        }

        public void ClickOnMakeBoldButton()
        {
            MakeBoldButton.Click();
        }
        public string GetBoldedTextFromIFrameField()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(frameId);
            string text = BoldedTextBoxInFrame.Text;
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
            return text;
        }
    }
}