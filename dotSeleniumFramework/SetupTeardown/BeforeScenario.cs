using System;
using System.IO;
using dotSeleniumFramework.Helpers;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace dotSeleniumFramework.SetupTeardown
{
    [Binding]
    public class BeforeScenario
    {
        [BeforeScenario(Order = 1)]
        public static void SetUp()
        {
            string settingsJson = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestSettings.json"));
            TestSettings settings = JsonConvert.DeserializeObject<TestSettings>(settingsJson);
            Driver.Initialize(settings);
        } 
    }
}