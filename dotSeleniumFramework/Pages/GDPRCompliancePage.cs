using dotSeleniumFramework.Helpers;
using dotSeleniumFramework.Pages.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace dotSeleniumFramework.Pages
{
    class GDPRCompliancePage : LoadablePage<GDPRCompliancePage>
    {
        private By breadCrumbsLocator => By.XPath("//li[@class='breadcrumbs__menuitem']//span[contains(text(),'EU GDPR')]");
        private IWebElement breadCrumbsElement => searchContext.FindElement(breadCrumbsLocator);

        private By headerTextLocator(string headerText) => 
            By.XPath($"//h1[@class='text__heading'][contains(text(),'{headerText}')]");
        private IWebElement headerTextElement(string headerText) =>
            searchContext.FindElement(headerTextLocator(headerText));

        private By downloadButtonLocator => By.XPath(".//parent::section//a[@class='text__button button--variant1']");
        
        public void DownloadEightSteps(string sectionHeader)
        {
            var eightStepsHeader = headerTextElement(sectionHeader);
            Driver.Instance.ExecuteJavaScript("arguments[0].scrollIntoView(true);", eightStepsHeader);

            eightStepsHeader.FindElement(downloadButtonLocator).Click();
        }

        protected override bool EvaluateLoadedStatus() => breadCrumbsElement.Displayed;
    }
}
