using dotSeleniumFramework.Helpers;
using TechTalk.SpecFlow;

namespace dotSeleniumFramework.StepDefinitions
{
    public class CommonSteps
    {
        [Given(@"I open (.*) website")]
        public void GivenIOpenWebsite(string url)
        {
            
        }

        [Then(@"(.*) webpage is loaded correctly")]
        public void ThenWebpageIsLoadedCorrectly(string webpage)
        {

        }

    }
}