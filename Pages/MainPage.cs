using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Inloop.Pages
{
    class MainPage
    {
        //Import keys from .runsettings file
        private readonly IWebDriver _driver;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");

        public MainPage(IWebDriver driver)
        {
            // constructor
            this._driver = driver;
        }

       
        public MainPage CloseCoockie()
            //close coockie pop-up
        {
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//a[@class='cc-btn cc-dismiss']")).Click();
            return this;
        }

        public MainPage NewsLetterPickChrome(bool chrome)
            // Scroll down and check newsletter click
        {

          
          


            List<IWebElement> news = _driver.FindElements(By.CssSelector("#newsletters-archive article a")).ToList();
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.End);
            Thread.Sleep(3000);

            if (chrome)
            {
                var element = _driver.FindElement(By.CssSelector("#newsletters-archive article a"));
                Actions actions = new Actions(_driver);
                actions.MoveToElement(element);
                actions.Perform();
                Thread.Sleep(2000);
            }

            for (int i = 0; i < news.Count; i++)
            {
                news[i].Click();
                Thread.Sleep(2000);
                Assert.IsTrue(_driver.PageSource.Contains("api/feedlandingapi/getnewslettertemplatebody?id="));
                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                _driver.Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                Thread.Sleep(2000);
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.Navigate().GoToUrl(_base_url);
            Thread.Sleep(5000);
            return this;
        }
        public MainPage NewsLetterPickFirefox()
        // Scroll down and check newsletter click
        {

            List<IWebElement> news = _driver.FindElements(By.CssSelector("#newsletters-archive article a")).ToList();
            //_driver.FindElement(By.TagName("body")).SendKeys(Keys.End);
            //var element = _driver.FindElement(By.CssSelector("#newsletters-archive article a"));
            //Actions actions = new Actions(_driver);
            //actions.MoveToElement(element);
            //actions.Perform();
            Thread.Sleep(2000);
            for (int i = 0; i < news.Count; i++)
            {
                news[i].Click();
                Thread.Sleep(2000);
                Assert.IsTrue(_driver.PageSource.Contains("api/feedlandingapi/getnewslettertemplatebody?id="));
                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                _driver.Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                Thread.Sleep(2000);
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.Navigate().GoToUrl(_base_url);
            Thread.Sleep(5000);
            return this;
        }
        public MainPage TapInTab1(string taglist)
            //Validation opening tematic tab "NATA"
        {
            _driver.FindElement(By.XPath(taglist)).Click();
            Assert.IsTrue(_driver.PageSource.Contains("entity/7/"));
            _driver.Navigate().Back();
            Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.Home);
            return this;
        }
        public MainPage PopularTab()
            //Validation opening popular tab
        {
            //_driver.FindElement(By.TagName("body")).SendKeys(Keys.End);
            //Thread.Sleep(2000);
            //var element = _driver.FindElement(By.XPath("//span[contains(text(),'Industry Tweets')]"));
            //Actions action = new Actions(_driver);
            //action.MoveToElement(element);
            //action.Perform();
            //Thread.Sleep(2000);
            List<IWebElement> pop = _driver.FindElement(By.XPath("//div[@class='widget reviewwidget ng-scope']")).FindElements(By.TagName("a")).ToList();
            for (int j = 0; j < pop.Count; j++)
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.LeftControl).Click(pop[j]).Build().Perform();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            return this;
        }
        //public MainPage RecentNews()
        ////checking recentNews NOT WORKED
        //{
        //    var element = _driver.FindElement(By.XPath("//section[1]//article[1]"));
        //    Actions actions = new Actions(_driver);
        //    actions.MoveToElement(element);
        //    actions.Perform();
        //    List<IWebElement> rec = _driver.FindElement(By.XPath("//div[@class='col-md-8 ng-scope']//article-plates[3]")).FindElements(By.TagName("a")).ToList();
        //    for (int i = 0; i < rec.Count; i++)
        //    {
        //        rec[i].Click();
        //        //Assert.IsFalse(_driver.PageSource.Contains(_base_url));
        //        _driver.Navigate().Back();
        //        Thread.Sleep(5000);
        //    }
        //    return this;
    public MainPage Personalization_conteiner()
        //Tap in personalization tabs
        {
            List<IWebElement> pers = _driver.FindElement(By.XPath("//div[@class='personalization-container']")).FindElements(By.TagName("p")).ToList();
            for (int i = 0; i < pers.Count; i++)
            {
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                pers[i].Click();
                Thread.Sleep(6000);
                //_driver.Navigate().Back();
                //Thread.Sleep(2000);
            }
            return this;
        }

    
    }
}
