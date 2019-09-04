using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Inloop.Pages
{
    class MainPage
    {
        private readonly IWebDriver _driver;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");

        public MainPage(IWebDriver driver)
        {
            // constructor
            this._driver = driver;
        }

        /// <summary>
        /// Closing coockie pop-up
        /// </summary>
        /// <returns>Closed coockie pop-up</returns>
        public MainPage CloseCoockie()
        {
            _driver.FindElement(By.XPath("//a[@class='cc-btn cc-dismiss']")).Click();
            return this;
        }

        /// <summary>
        /// Scroll in the end page and check newsletter click
        /// </summary>
        /// <param name="chrome"></param>
        /// <returns>Opened all available newsletter </returns>
        public MainPage NewsLetterPickChrome(bool chrome)
        {
            List<IWebElement> news = _driver.FindElements(By.CssSelector("#newsletters-archive article a")).ToList();
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.End);

            if (chrome)
            {
                var element = _driver.FindElement(By.CssSelector("#newsletters-archive article a"));
                Actions actions = new Actions(_driver);
                actions.MoveToElement(element);
                actions.Perform();
            }

            for (int i = 0; i < news.Count; i++)
            {
                news[i].Click();
                Assert.IsTrue(_driver.PageSource.Contains("api/feedlandingapi/getnewslettertemplatebody?id="));
                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                _driver.Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                Thread.Sleep(2000); 
            }
            _driver.Navigate().GoToUrl(_base_url);
            return this;
        }

        /// <summary>
        /// Validation opening tematic tab (upper page categorys)
        /// </summary>
        /// <param name="taglist"></param>
        /// <param name="tag_assert"></param>
        /// <returns>Opened tenatic tabs</returns>
        public MainPage TapInTab1(string taglist, string tag_assert)
        {
            _driver.FindElement(By.XPath(taglist)).Click();
            Assert.IsTrue(_driver.PageSource.Contains(tag_assert));
            _driver.Navigate().Back();
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.Home);
            return this;
        }

        /// <summary>
        /// Validation opening popular tab
        /// </summary>
        /// <returns>Opened popular tab</returns>
        public MainPage PopularTab()
        {
            List<IWebElement> pop = _driver.FindElement(By.XPath("//div[@class='widget reviewwidget ng-scope']")).FindElements(By.TagName("a")).ToList();
            for (int j = 0; j < pop.Count; j++)
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.LeftControl).Click(pop[j]).Build().Perform();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            return this;
        }

        /// <summary>
        /// Tap in personalization tabs
        /// </summary>
        /// <returns>Opened personalization tabs</returns>
        public MainPage Personalization_conteiner()
        {
            List<IWebElement> pers = _driver.FindElement(By.XPath("//div[@class='personalization-container']")).FindElements(By.TagName("p")).ToList();
            for (int i = 0; i < pers.Count; i++)
            {
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                pers[i].Click();
            }
            return this;
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


    }
}
