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

        public Login A_LoginUser()
            //Validation of correct login user
        {
            _driver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click();
            _driver.FindElement(By.XPath("//form[@name='signInForm']//input[@placeholder='Email Address']")).SendKeys("romareverse9@gmail.com");
            _driver.FindElement(By.XPath("//form[@name='signInForm']//input[@placeholder='Password']")).SendKeys("ezykatka322");
            Thread.Sleep(3000);
            Actions actions = new Actions(_driver);
            IWebElement elementLocator = _driver.FindElement(By.XPath("//button[@class='submit google-analize ng-binding']"));
            actions.DoubleClick(elementLocator).Perform();
            Thread.Sleep(10000);
            Assert.IsTrue(_driver.PageSource.Contains(_base_url));
            return this;
        }
        public Login B_DropDownAcc_personalize()
            //Check drop bar and personalize tab
        {
            _driver.FindElement(By.XPath("//div[@class='menu-wrapper google-analize not-internal-users']")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[2]/div[2]/div[1]/div")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/personalization"));
            return this;
        }
        public Login C_Foloving()
            //Check tematic tabs
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'Following')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'My news')]")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("my?type=tracked"));
            _driver.Navigate().Back();
            Thread.Sleep(5000);
            return this;
        }
        public Login D_Sorting()
            //Check sorting tab
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'categories')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'publishers')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'companies')]")).Click();
            _driver.FindElement(By.XPath("//li[@class='hidden-mobile']")).Click();
            _driver.FindElement(By.XPath("//label[contains(text(),'list view')]")).Click();
            return this;
        }
        public Login E_DropBar()
            //Autorized drop bar
        {
            _driver.FindElement(By.XPath("//button[@class='menu menu-desktop']")).Click();
            _driver.FindElement(By.XPath("//ul[@class='down-menu ng-isolate-scope']//a[contains(text(),'My Profile')]")).Click();
            Thread.Sleep(4000);
            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/profiledetails"));
            return this;
        }
        public Login My_newsfeed()
        //newsfeed check
        {
            List<IWebElement> top = _driver.FindElement(By.XPath("//div[@class='navbar-collapse collapse']")).FindElements(By.TagName("a")).ToList();
            for (int i = 0; i < top.Count; i++)
            {
                Actions actions = new Actions(_driver);
                actions.KeyDown(Keys.LeftControl).Click(top[i]).Build().Perform();
                Thread.Sleep(5000);
                var browserTabs = _driver.WindowHandles;
                _driver.SwitchTo().Window(browserTabs[1]);
                _driver.Close();
                _driver.SwitchTo().Window(browserTabs[0]);
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);

            return this;
        }
        public Login Mainpage()
        //go to main page
        {
            _driver.Navigate().GoToUrl(_base_url);
            Assert.IsTrue(_driver.PageSource.Contains(_base_url));
            return this;
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