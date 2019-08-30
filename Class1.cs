using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace firsttrip
{
    public class Firsttrip
    {
        protected IWebDriver Driver;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");

        public Firsttrip()
        {
            Driver = new ChromeDriver(new ChromeOptions());
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Navigate().GoToUrl(_base_url);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Driver.Quit();
        }
    }
}
