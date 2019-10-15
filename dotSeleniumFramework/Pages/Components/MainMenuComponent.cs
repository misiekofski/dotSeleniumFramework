using dotSeleniumFramework.Helpers;
using dotSeleniumFramework.Pages.Abstract;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace dotSeleniumFramework.Pages.Components
{
    class MainMenuComponent : LoadablePage<MainMenuComponent>
    {
        protected override By componentContainerLocator => By.XPath("//ul[@class='header__menulist']");
        protected override IWebElement componentContainer => searchContext.FindElement(componentContainerLocator);

        private By secondLevelMenuLocator(string secondLevelText) => By.XPath($"//a[contains(text(), '{secondLevelText}')]");
        private IWebElement secondLevelMenuItem(string secondLevelText) => componentContainer.FindElement(secondLevelMenuLocator(secondLevelText));

        private By firstLevelMenuItemLocator(string firstLevelText) => 
            By.XPath($".//li[contains(@class, 'header__menuitem--megamenu')]//a[contains(text(), '{firstLevelText}')]");

        private IWebElement firstLevelMenuItem(string firstLevelText) =>
            componentContainer.FindElement(firstLevelMenuItemLocator(firstLevelText));


        public void SelectMenu(string firstLevelMenuText, string secondLevelMenuText)
        {
            var firstElement = firstLevelMenuItem(firstLevelMenuText);
            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(firstElement);
            action.Perform();

            secondLevelMenuItem(secondLevelMenuText).Click();
        }

        protected override bool EvaluateLoadedStatus() => componentContainer.Displayed;
    }
}
