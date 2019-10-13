using System;
using dotSeleniumFramework.Helpers.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace dotSeleniumFramework.Helpers
{
    public class Driver
    {
        private static IWebDriver driver;
        private static string DownloadFolder;

        private Driver(TestSettings testSettings)
        {
            DownloadFolder = testSettings.DownloadFolder;
            BrowserType browserType = testSettings.CurrentBrowser;

            switch (browserType)
            {
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;

                case BrowserType.Chrome:
                default:
                    var chromeOptions = new ChromeOptions();
                    if (testSettings.RunAsHeadless)
                        chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-single-click-autofill");
                    chromeOptions.AddUserProfilePreference(("download.default_directory"), DownloadFolder);
                    driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions, TimeSpan.FromMinutes(10));
                    break;

            }

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        public static Driver Initialize(TestSettings settings) => new Driver(settings);

    }
}
