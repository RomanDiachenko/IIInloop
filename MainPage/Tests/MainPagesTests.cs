using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            private readonly string _tag_assert1 = TestContext.Parameters.Get("tag_assert1");
            private readonly string _tag_assert2 = TestContext.Parameters.Get("tag_assert2");
            private readonly string _tag_assert3 = TestContext.Parameters.Get("tag_assert3");
            private readonly string _tag_assert4 = TestContext.Parameters.Get("tag_assert4");
            private readonly string _tag_assert5 = TestContext.Parameters.Get("tag_assert5");
            private readonly string _tag_assert6 = TestContext.Parameters.Get("tag_assert6");
            private readonly string _tag_assert7 = TestContext.Parameters.Get("tag_assert7");
            private readonly string _tag_assert8 = TestContext.Parameters.Get("tag_assert8");
            private readonly string _navigaton_but1 = TestContext.Parameters.Get("navigaton_but1");
            private readonly string _navigaton_but2 = TestContext.Parameters.Get("navigaton_but2");
            private readonly string _navigaton_but3 = TestContext.Parameters.Get("navigaton_but3");
            private readonly string _navigaton_but4 = TestContext.Parameters.Get("navigaton_but4");
            private readonly string _navigaton_but5 = TestContext.Parameters.Get("navigaton_but5");
            private readonly string _navigaton_assert1 = TestContext.Parameters.Get("navigaton_assert1");
            private readonly string _navigaton_assert2 = TestContext.Parameters.Get("navigaton_assert2");
            private readonly string _navigaton_assert3 = TestContext.Parameters.Get("navigaton_assert3");
            private readonly string _navigaton_assert4 = TestContext.Parameters.Get("navigaton_assert4");
            private readonly string _navigaton_assert5 = TestContext.Parameters.Get("navigaton_assert5");
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
                else if (typeof(TWebDriver).Name == "EdgeDriver")
                {
                    _driver = new EdgeDriver();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(_base_url);
            }


            [Test]
            public void A_NewsletterPicker()
            {
                bool chrome = (typeof(TWebDriver).Name == "ChromeDriver");
                _mainPage = new MainPage(_driver);

                _mainPage = _mainPage.CloseCoockie();
                _mainPage = _mainPage.NewsLetterPickChrome(chrome);
            }


            [Test]
            public void B_TapIn1Tab()
            {
                _mainPage = new MainPage(_driver);

                _mainPage = _mainPage.TapInTab1(_tag_list1, _tag_assert1);
                _mainPage = _mainPage.TapInTab1(_tag_list2, _tag_assert2);
                _mainPage = _mainPage.TapInTab1(_tag_list3, _tag_assert3);
                _mainPage = _mainPage.TapInTab1(_tag_list4, _tag_assert4);
                _mainPage = _mainPage.TapInTab1(_tag_list5, _tag_assert5);
                _mainPage = _mainPage.TapInTab1(_tag_list6, _tag_assert6);
                _mainPage = _mainPage.TapInTab1(_tag_list7, _tag_assert7);
                _mainPage = _mainPage.TapInTab1(_tag_list8, _tag_assert8);
            }
            [Test]
            public void C_PopularTab1()
            {
                _mainPage = new MainPage(_driver);

                _mainPage = _mainPage.A_LoginUser();
                _mainPage = _mainPage.TopNavigation(_navigaton_but1, _navigaton_assert1);
                _mainPage = _mainPage.TopNavigation(_navigaton_but2, _navigaton_assert2);
                _mainPage = _mainPage.TopNavigation(_navigaton_but3, _navigaton_assert3);
                _mainPage = _mainPage.TopNavigation(_navigaton_but4, _navigaton_assert4);
                _mainPage = _mainPage.TopNavigation(_navigaton_but5, _navigaton_assert5);
                //_mainPage = _mainPage.PopularTab();
            }

            [Test]
            public void D_Tags()
            {
                _mainPage = new MainPage(_driver);

                //_mainPage = _mainPage.CloseCoockie();
                _mainPage = _mainPage.Tags();

            }



            [OneTimeTearDown]
            public void TearDown()
            {
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);

                _driver.Quit();
            }
        }
    }
}
