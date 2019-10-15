using System;
using System.Linq;
using dotSeleniumFramework.Helpers;
using dotSeleniumFramework.Pages;
using dotSeleniumFramework.Pages.Components;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
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

        [When(@"I select menu ""(.*)"" -> ""(.*)""")]
        public void WhenISelectMenu_(string firstLevelMenu, string secondLevelMenu)
        {
            var mainMenuComponent = new MainMenuComponent();
            mainMenuComponent.SelectMenu(firstLevelMenu, secondLevelMenu);
        }

        [When(@"Create screenshot of current page")]
        public void WhenCreateScreenshotOfCurrentPage()
        {
            Driver.Instance.TakeScreenshot()
                .SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "-screenshot.png", ScreenshotImageFormat.Png);
        }

        [When(@"I scroll down to ""(.*)"" and click download button in this section")]
        public void WhenIScrollDownToAndClickDownloadButtonInThisSection(string sectionText)
        {
            var gdprPage = new GDPRCompliancePage();
            gdprPage.DownloadEightSteps(sectionText);
        }

        [Then(@"New tab is opened with url ""(.*)""")]
        public void ThenIMNewTabIsOpenedWithUrl(string url)
        {
            var currentUrl = Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last()).Url;
            Assert.AreEqual(currentUrl,url);

            var downloadBookPage = new DownloadGDPREbookPage();
        }

    }
}
