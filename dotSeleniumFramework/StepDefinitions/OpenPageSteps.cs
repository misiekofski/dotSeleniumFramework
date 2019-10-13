using System;
using dotSeleniumFramework.Helpers;
using dotSeleniumFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace dotSeleniumFramework.StepDefinitions
{
    [Binding]
    public class OpenPageSteps
    {
        [Given(@"I open (.*) website")]
        public void GivenIOpenHttpsWebsite(string url)
        {
            Driver.Instance.Url = url;
            var mainPage = new MainPage();
            mainPage.CloseCookiePopup();
        }
        
        [Then(@"(.*) webpage is loaded correctly")]
        public void ThenWebpageIsLoadedCorrectly(string webpage)
        {
            
        }
    }
}
