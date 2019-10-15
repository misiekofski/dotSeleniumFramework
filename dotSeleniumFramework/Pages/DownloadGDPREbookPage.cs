using dotSeleniumFramework.Pages.Abstract;
using OpenQA.Selenium;

namespace dotSeleniumFramework.Pages
{
    public class DownloadGDPREbookPage : LoadablePage<DownloadGDPREbookPage>
    {
        private By headerLocator => By.XPath("//h1[contains(text(), 'Comply with the EU General Data Protection Regulation')]");
        private IWebElement header => searchContext.FindElement(headerLocator);

        protected override bool EvaluateLoadedStatus() => header.Displayed;
    }
}