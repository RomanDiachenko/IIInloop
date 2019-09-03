using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Inloop.Pages;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace Inloop
{
    class MainPagesTests
    {

        [TestFixture(typeof(FirefoxDriver))]
        [TestFixture(typeof(ChromeDriver))]
        //[TestFixture(typeof(EdgeDriver))]
        public class Tests<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");
            private readonly string _tag_list1 = TestContext.Parameters.Get("tag_list1");
            private readonly string _tag_list2 = TestContext.Parameters.Get("tag_list2");
            private readonly string _tag_list3 = TestContext.Parameters.Get("tag_list3");
            private readonly string _tag_list4 = TestContext.Parameters.Get("tag_list4");
            private readonly string _tag_list5 = TestContext.Parameters.Get("tag_list5");
            private readonly string _tag_list6 = TestContext.Parameters.Get("tag_list6");
            private readonly string _tag_list7 = TestContext.Parameters.Get("tag_list7");
            private readonly string _tag_list8 = TestContext.Parameters.Get("tag_list8");
            public IWebDriver _driver;
            private MainPage _mainPage;
            public TestContext TestContext { get; set; }
            public static readonly TestParameters testParams;


            [OneTimeSetUp]
            public void Setup()
            {
                if (typeof(TWebDriver).Name == "ChromeDriver")
                {
                    _driver = new ChromeDriver();
                }
                else if (typeof(TWebDriver).Name == "FirefoxDriver")
                {
                    _driver = new FirefoxDriver();
                }
                //else if (typeof(TWebDriver).Name == "EdgeDriver")
                //{
                //    _driver = new EdgeDriver();
                //}
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(_base_url);
                Thread.Sleep(10000);
            }

            //Press in first few newsletter, after pressing close opened tab

            [Test]
            public void A_NewsletterPicker()
            {
                bool chrome = (typeof(TWebDriver).Name == "ChromeDriver");
                _mainPage = new MainPage(_driver);
                _mainPage = _mainPage.CloseCoockie();
                _mainPage = _mainPage.NewsLetterPickChrome(chrome);
                
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
            public void B_TapIn1Tab()
            {
                _mainPage = new MainPage(_driver);

                _mainPage = _mainPage.TapInTab1(_tag_list1);
                _mainPage = _mainPage.TapInTab1(_tag_list2);
                _mainPage = _mainPage.TapInTab1(_tag_list3);
                _mainPage = _mainPage.TapInTab1(_tag_list4);
                _mainPage = _mainPage.TapInTab1(_tag_list5);
                _mainPage = _mainPage.TapInTab1(_tag_list6);
                _mainPage = _mainPage.TapInTab1(_tag_list7);
                _mainPage = _mainPage.TapInTab1(_tag_list8);
            }
            [Test]
            public void C_PopularTab1()
            {
                _mainPage = new MainPage(_driver);

                //_mainPage = _mainPage.CloseCoockie();
                _mainPage = _mainPage.PopularTab();
                //_mainPage = _mainPage.RecentNews();
                ////_mainPage = _mainPage.Personalization_conteiner();
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
}
