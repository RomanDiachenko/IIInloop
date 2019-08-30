using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Inloop.Pages;



namespace Inloop
{
    class MainPagesTests
    {

        public IWebDriver _driver;
        private MainPage _mainPage;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");
        public TestContext TestContext { get; set; }
        public static readonly TestParameters testParams;


        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_base_url);
            Thread.Sleep(10000);
        }

        //Press in first few newsletter, after pressing close opened tab
        [Test]
        public void a_NewsletterPicker()
        {
            _mainPage = new MainPage(_driver);
            _mainPage = _mainPage.ClickElement();
            _mainPage = _mainPage.NewsLetterPick();

        }

        //Demo form crashing captcha
        //[Test]
        //public void ReCaptcha()
        //{
        //    _driver.FindElement(By.XPath("//input[@placeholder='Your Email']")).SendKeys("aa@aa.aa");
        //    IWebElement frame = _driver.FindElements(By.XPath("//iframe[contains(@src, 'recaptcha')]"))[0];
        //    _driver.SwitchTo().Frame(frame);
        //    IWebElement checkbox = _driver.FindElement(By.CssSelector("div.recaptcha-checkbox-border"));
        //    checkbox.Click();
        //    Thread.Sleep(5000);
        //}

        
        [Test]
        // Tap in tematic tabs
        public void b_TapIn1Tab()
        {
            _mainPage = new MainPage(_driver);

            _mainPage = _mainPage.TapInTab1();
            _mainPage = _mainPage.TapInTab2();
            _mainPage = _mainPage.TapInTab3();
            _mainPage = _mainPage.TapInTab4();
            _mainPage = _mainPage.TapInTab5();
            _mainPage = _mainPage.TapInTab6();
            _mainPage = _mainPage.TapInTab7();
            _mainPage = _mainPage.TapInTab8();
        }
        [Test]
        public void c_PopularTab1()
        {
            _mainPage = new MainPage(_driver);

            _mainPage = _mainPage.PopularTab();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            Assert.IsTrue(_driver.PageSource.Contains(_base_url));
            Thread.Sleep(10000);


            _driver.Quit();
        }
    }
}
