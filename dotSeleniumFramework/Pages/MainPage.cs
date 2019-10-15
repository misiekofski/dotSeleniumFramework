using dotSeleniumFramework.Pages.Abstract;
using OpenQA.Selenium;

namespace dotSeleniumFramework.Pages
{
    public class MainPage : LoadablePage<MainPage>
    {
        public MainPage() { }

        private By logoImageLocator => By.XPath("//img[@class='header__logo']");
        private IWebElement logoImage => searchContext.FindElement(logoImageLocator);

        private By closeCookiePopupButtonLocator => By.XPath("//span[contains(@class, 'cookiebar__button')]");
        private IWebElement closeCookiePopupButton => searchContext.FindElement(closeCookiePopupButtonLocator);

        protected override bool EvaluateLoadedStatus() => logoImage.Displayed && closeCookiePopupButton.Enabled;

        public void CloseCookiePopup() => closeCookiePopupButton.Click();

    }
}
