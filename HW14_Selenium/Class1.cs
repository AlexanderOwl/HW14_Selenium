using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW14_Selenium
{
    [TestFixture]
    public class BasicSiteWorkTest
    {
        IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\HW14 Selenium\HW14_Selenium\packages\Selenium.WebDriver.ChromeDriver.85.0.4183.8700\driver\win32");

        [Test]
        public void GoToDeveducationKyev()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer.kyiv-point"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://kyiv.deveducation.com/", pageUrl);
        }

        [Test]
        public void GoToDeveducationDnipro()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer.dnipro-point"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://dnipro.deveducation.com/", pageUrl);
        }

        [Test]
        public void GoToDeveducationKharkiv()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer.kharkiv-point"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://kharkiv.deveducation.com/", pageUrl);
        }

        [Test]
        public void GoToDeveducationBaku()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer.baku-point"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://baku.deveducation.com/", pageUrl);
        }

        [Test]
        public void GoToDeveducationSPB()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer.piter-point"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://spb.deveducation.com/", pageUrl);
        }

        //[Test]
        //public void CertificateAuthentication()
        //{
        //    chrome.Navigate().GoToUrl("https://deveducation.com/");
        //    chrome.Manage().Window.Maximize();
        //    IWebElement element = chrome.FindElement(By.ClassName("btn btn-color modal-btn bridge2__btn"));
        //    element.Click();
        //    //string pageUrl = chrome.Url;
        //    //Assert.AreEqual("https://spb.deveducation.com/", pageUrl);
        //}


        [OneTimeTearDown]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }


}
