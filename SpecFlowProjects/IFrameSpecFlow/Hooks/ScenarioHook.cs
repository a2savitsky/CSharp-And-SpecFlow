using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using TechTalk.SpecFlow;
using extension.JsonUtils;

namespace OnlinerSpecFlow.Hooks
{
    [Binding]
    public class ScenarioHook
    {
        protected string url => DataFromJsonFile.GetDataByKey("url");

        [BeforeScenario]
        public void BeforeScenario()
        {
            Logger.Instance.Info($"Starting browser with {url}");
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(url);
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