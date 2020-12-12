using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using TechTalk.SpecFlow;

namespace BasicAuthorizationSpecFlowProject.Hooks
{
    [Binding]
    public class ScenarioHook
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Logger.Instance.Info("Starting browser");
            AqualityServices.Browser.Maximize();
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