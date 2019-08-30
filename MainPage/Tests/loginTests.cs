using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using InloopLogin.Pages;

namespace InloopLogin
{
    class loginSDropbar
    {
        public IWebDriver _driver;
        private login _testLogin;
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
        [Test]
        public void a_login()
        {
            _testLogin = new login(_driver);

            _testLogin = _testLogin.a_LoginUser();
        }
        [Test]
        public void b_personalize()
        {
            _testLogin = _testLogin.b_DropDownAcc_personalize();
            _testLogin = _testLogin.c_Foloving();
            _testLogin = _testLogin.d_Sorting();
            _testLogin = _testLogin.e_DropBar();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            Thread.Sleep(10000);


            _driver.Quit();
        }
    }
}


