using TechTalk.SpecFlow;
using IFrameSpecFlow.Forms;
using extension.RandomUtils;
using NUnit.Framework;

namespace IFrameSpecFlow.Steps
{
    [Binding]
    public class IFrameTestingSteps
    {
        private MainPage mainPage;

        private readonly string RandString;

        public IFrameTestingSteps()
        {
            mainPage = new MainPage();
            RandString = DataGenerator.GetRandomString();
        }

        [Given(@"Site with IFrame")]
        public void GivenSiteWithIFrame()
        {
            Assert.True(mainPage.State.WaitForDisplayed(), "Main page is not open");
        }
        
        [When(@"I clear text field and input into it random string")]
        public void WhenIClearTextFieldAndInputIntoItRandomString()
        {
            mainPage.InputTextInFrame(RandString);
        }
        
        [When(@"I highlight the text and press 'B' button")]
        public void WhenIHighlightTheTextAndPressButton()
        {
            mainPage.HighlightTextInFrame();
            mainPage.ClickOnMakeBoldButton();
        }
        
        [Then(@"Inputted text is present in text field")]
        public void ThenInputtedTextIsPresentInTextField()
        {
            Assert.AreEqual(mainPage.GetTextFromIFrameField(), RandString, "Inputted text is not present in text field");
        }
        
        [Then(@"Inputted text is displayed in bold")]
        public void ThenInputtedTextIsDisplayedInBold()
        {
            Assert.AreEqual(mainPage.GetBoldedTextFromIFrameField(), RandString, "Inputted text is not bold");
        }
    }
}