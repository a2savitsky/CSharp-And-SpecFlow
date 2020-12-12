using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using TechTalk.SpecFlow;
using OnlinerSpecFlow.JsonUtils;
using OnlinerSpecFlow.Models;

namespace OnlinerSpecFlow.Hooks
{
    [Binding]
    public class ScenarioHook
    {
        protected string url => DataFromJsonFile.GetDataByKey("url");
        
        protected string pathToCredFile = @"TestData\credentials.json";

        [BeforeScenario]
        public void BeforeScenario()
        {
            Logger.Instance.Info($"Starting browser with {url}");
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(url);
            User.SetCredentials(DataFromJsonFile.GetDataByKey("user", pathToCredFile), 
                DataFromJsonFile.GetDataByKey("password", pathToCredFile));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger.Instance.Info("Start CleanUp method after test");
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}