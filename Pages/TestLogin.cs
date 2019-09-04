using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InloopLogin.Pages
{
    class Login
    {
        private readonly IWebDriver _driver;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");
        public Login(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Validation of correct login user
        /// </summary>
        /// <returns>Login valid</returns>
        public Login A_LoginUser()
        {
            _driver.Navigate().GoToUrl(_base_url);
            _driver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click();
            _driver.FindElement(By.XPath("//form[@name='signInForm']//input[@placeholder='Email Address']")).SendKeys("romareverse9@gmail.com");
            _driver.FindElement(By.XPath("//form[@name='signInForm']//input[@placeholder='Password']")).SendKeys("ezykatka322");
            Actions actions = new Actions(_driver);
            IWebElement elementLocator = _driver.FindElement(By.XPath("//button[@class='submit google-analize ng-binding']"));
            actions.DoubleClick(elementLocator).Perform();
            Assert.IsTrue(_driver.PageSource.Contains(_base_url));
            return this;
        }

        /// <summary>
        /// Check drop bar and personalize tab
        /// </summary>
        /// <returns>Drop bar and personalization tab works</returns>
        public Login B_DropDownAcc_personalize()
        {
            _driver.FindElement(By.XPath("//div[@class='menu-wrapper google-analize not-internal-users']")).Click();
            _driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[2]/div[2]/div[1]/div")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/personalization"));
            return this;
        }

        /// <summary>
        /// Check tematic tabs
        /// </summary>
        /// <returns>Tematic tabs are worked</returns>
        public Login C_Foloving()
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'Following')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'My news')]")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("my?type=tracked"));
            _driver.Navigate().Back();
            return this;
        }

        /// <summary>
        /// Check sorting tab
        /// </summary>
        /// <returns>Sorting tab are worked</returns>
        public Login D_Sorting()
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'categories')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'publishers')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'companies')]")).Click();
            _driver.FindElement(By.XPath("//li[@class='hidden-mobile']")).Click();
            _driver.FindElement(By.XPath("//label[contains(text(),'list view')]")).Click();
            return this;
        }

        /// <summary>
        /// Check "My profile" tab in drop bar
        /// </summary>
        /// <returns>"My profile" opened in walid page</returns>
        public Login E_DropBar()
        {
            _driver.FindElement(By.XPath("//button[@class='menu menu-desktop']")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'My Profile')]")).Click();

            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/profiledetails"));
            return this;
        }

        /// <summary>
        /// Check newsletter
        /// </summary>
        /// <returns>Newsletters are worked</returns>
        public Login My_newsfeed()
        {
            List<IWebElement> top = _driver.FindElement(By.XPath("//div[@class='navbar-collapse collapse']")).FindElements(By.TagName("a")).ToList();
            for (int i = 0; i < top.Count; i++)
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.LeftControl).Click(top[i]).Build().Perform();
                Thread.Sleep(5000);
                _driver.SwitchTo().Window(_driver.WindowHandles[1]).Close();
                Thread.Sleep(5000);

                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            }

            return this;
        }

        /// <summary>
        /// Go to main page
        /// </summary>
        /// <returns>Opened main page</returns>
        public Login Mainpage()
        {
            _driver.Navigate().GoToUrl(_base_url);
            Assert.IsTrue(_driver.PageSource.Contains(_base_url));
            return this;
        }
    }
}