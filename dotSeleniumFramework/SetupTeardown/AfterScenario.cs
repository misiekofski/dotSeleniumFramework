using dotSeleniumFramework.Helpers;
using TechTalk.SpecFlow;

namespace dotSeleniumFramework.SetupTeardown
{
    [Binding]
    public class AfterScenario
    {
        [AfterScenario(Order = 1000)]
        public static void TearDown() => Driver.Instance.Quit();
    }
}