using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace InloopLogin.Pages
{
    class login
    {
        private IWebDriver _driver;
        private readonly string _base_url = TestContext.Parameters.Get("BaseUrl");
        public login(IWebDriver driver)
        {
            this._driver = driver;
        }

        public login a_LoginUser()
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
        public login b_DropDownAcc_personalize()
            //Check drop bar and personalize tab
        {
            _driver.FindElement(By.XPath("//button[@class='menu menu-desktop']")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Personalize my news')]")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/personalization"));
            return this;
        }
        public login c_Foloving()
            //Check tematic tabs
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'Following')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'My news')]")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("my?type=tracked"));
            _driver.Navigate().Back();
            Thread.Sleep(5000);
            return this;
        }
        public login d_Sorting()
            //Check sorting tab
        {
            _driver.FindElement(By.XPath("//li[contains(text(),'categories')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'publishers')]")).Click();
            _driver.FindElement(By.XPath("//li[contains(text(),'companies')]")).Click();
            _driver.FindElement(By.XPath("//li[@class='hidden-mobile']")).Click();
            _driver.FindElement(By.XPath("//label[contains(text(),'list view')]")).Click();
            return this;
        }
        public login e_DropBar()
            //Autorized drop bar
        {
            _driver.FindElement(By.XPath("//button[@class='menu menu-desktop']")).Click();
            _driver.FindElement(By.XPath("//ul[@class='down-menu ng-isolate-scope']//a[contains(text(),'My Profile')]")).Click();
            Thread.Sleep(4000);
            Assert.IsTrue(_driver.PageSource.Contains("trackeruser/profiledetails"));
            return this;
        }
        public login my_newsfeed()
        //newsfeed check
        {
            _driver.FindElement(By.XPath("//li[@class='dropdown menu-color1 active']//a[@class='ng-scope'][contains(text(),'My newsfeed')]")).Click();
            Assert.IsTrue(_driver.PageSource.Contains("my?type=tracked"));
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