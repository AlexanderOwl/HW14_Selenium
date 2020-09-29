using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace HW14_Selenium
{
    [TestFixture]
    public class BasicSiteWorkTest
    {
        IWebDriver chrome;
        
        [Test(Description = "On click ico Facebook must navigate to deveduaction page on facebook")] 
        public void GoToFacebookInFooter()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");

            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > footer > div > ul > li:nth-child(2) > a"));
            element.Click();
            chrome.SwitchTo().Window(chrome.WindowHandles.Last());
            //new Actions(chrome).SendKeys(chrome.FindElement(By.TagName("html")), Keys.Control).SendKeys(chrome.FindElement(By.TagName("html")), Keys.).Build().Perform();            
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://www.facebook.com/IT.DevEducation/", pageUrl);
        }

        [TestCase("https://wizardsdev.com/","wizardsdev", Description = "On click logo wizardsdev must navigate to their site")]
        [TestCase("https://www.finversia.ru/", "finversia", Description = "On click logo finversia must navigate to their site")]
        [TestCase("https://xcritical.software/", "xcritical", Description = "On click logo xcritical must navigate to their site")]
        [TestCase("https://necsi.edu/", "necsi", Description = "On click logo necsi must navigate to their site")]
        [TestCase("https://linguatrip.com/en/", "linguatrip", Description = "On click logo linguatrip must navigate to their site")]        
        [TestCase("https://beaxy.com/", "beaxy", Description = "On click logo beaxy must navigate to their site")]        
        public void GoToPartnersInKyiv(string url,string alt)
        {
            chrome.Navigate().GoToUrl("https://kyiv.deveducation.com/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement element = chrome.FindElement(By.CssSelector($"img[alt=\"{alt}\"]"));
            element.Click();
            chrome.SwitchTo().Window(chrome.WindowHandles.Last());
            string pageUrl = chrome.Url;
            Assert.AreEqual(url, pageUrl);
        }

        [TestCase("https://kyiv.deveducation.com/courses/frontend/", "1", Description = "Transition to profession FrontEnd in branch Kyiv")]
        [TestCase("https://kyiv.deveducation.com/courses/basic/", "2", Description = "Transition to profession С# in branch Kyiv")]
        [TestCase("https://kyiv.deveducation.com/courses/qa-manual-automation/", "3", Description = "Transition to profession QA in branch Kyiv")]
        [TestCase("https://kyiv.deveducation.com/courses/java/", "4", Description = "Transition to profession Java in branch Kyiv")]
        [TestCase("https://kyiv.deveducation.com/courses/bookkeeping/", "5", Description = "Transition to profession Bookkeeping in branch Kyiv")]
        [TestCase("https://kyiv.deveducation.com/courses/react-native/", "6", Description = "Transition to profession Mobile React Native in branch Kyiv")]
        public void GoToProfession(string expextedUrl, string point)
        {
            chrome.Navigate().GoToUrl("https://kyiv.deveducation.com/courses/");

            string selector = $"body > div.wrapper.sub > footer > div > ul.standard-footer__courses-list > li:nth-child({point}) > a";
            IWebElement element = chrome.FindElement(By.CssSelector(selector));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual(expextedUrl, pageUrl);
        }
        [Test(Description = "Navigate from kyiv page to dnipro page")]
        public void ChangeBranchKyivToDnipro()
        {
            chrome.Navigate().GoToUrl("https://kyiv.deveducation.com/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement elementPopup = chrome.FindElement(By.CssSelector("body > div.wrapper.sub > main > div.popups.subscribe-pop.closing-pop.show > div > button"));
            elementPopup.Click();

            IWebElement elementClickAllCity = chrome.FindElement(By.CssSelector("body > div.wrapper.sub > div > header > div > div._header__lists > ul > li:nth-child(2) > button"));
            elementClickAllCity.Click();

            IWebElement elementCityDnipro = chrome.FindElement(By.CssSelector("body > div.wrapper.sub > div > header > div > div._header__lists > ul > li:nth-child(2) > ul > li:nth-child(2) > a"));
            elementCityDnipro.Click();

            string pageUrl = chrome.Url;
            Assert.AreEqual("https://dnipro.deveducation.com/", pageUrl);
        }

        [Test(Description = "Navigate to first article on news")] 
        public void GoToArticleOnEventsPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/events/");

            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > div > div > div.container.blog-archive > div > ul > li:nth-child(1) > figure > a"));
            element.Click();
            IWebElement text = chrome.FindElement(By.ClassName("event-page__title"));
            string pageUrl = text.Text;
            Assert.AreEqual("Обучение на реальном проекте – это бесценный опыт и практика!", pageUrl);
        }

        [Test(Description = "Button must load new artiles on news page, in total 9")] 
        public void LoadMoreButtonOnEventsPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/events/");
            IWebElement element = chrome.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[1]"));
            element.Click();
            int recordsCount = chrome.FindElement(By.ClassName("events-list")).FindElements(By.TagName("li")).Count;
            Assert.AreEqual(9, recordsCount);
        }


        [Test(Description = "Navigate to first article on blog")] 
        public void GoToArticleOnBlogPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/blog/");

            IWebElement element = chrome.FindElement(By.CssSelector("body > div.wrapper > main > div > div > div.container.blog-archive > div > ul > li:nth-child(1) > figure > a"));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual("https://deveducation.com/blog/kakoy-yazyk-programmirovaniya-vybrat-dlya-starta/", pageUrl);
        }

        [Test(Description = "Button must load new artiles on blog page, in total 9")] 
        public void LoadMoreButtonOnBlogPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/blog/");
            IWebElement element = chrome.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[1]/div/div[1]"));
            element.Click();
            int recordsCount = chrome.FindElement(By.ClassName("events-list")).FindElements(By.TagName("li")).Count;
            Assert.AreEqual(9, recordsCount);
        }
        
        [TestCase("https://kyiv.deveducation.com/", "kyiv-point", Description = "Transition from the main menu to the site of the branch in Kyiv")]  
        [TestCase("https://dnipro.deveducation.com/", "dnipro-point", Description = "Transition from the main menu to the site of the branch in Dnipro")]  
        [TestCase("https://kharkiv.deveducation.com/", "kharkiv-point", Description = "Transition from the main menu to the site of the branch in Kharkiv")]  
        [TestCase("https://baku.deveducation.com/", "baku-point", Description = "Transition from the main menu to the site of the branch in Baku")]
        [TestCase("https://spb.deveducation.com/", "piter-point", Description = "Transition from the main menu to the site of the branch in St.Peterburg")]  
        public void GoFromDeveducationKyiv(string expextedUrl, string point)
        {
            string selector = "body > div.wrapper > main > section > div > div.map-container > div > a.map-pointer." + point;
            IWebElement element = chrome.FindElement(By.CssSelector(selector));
            element.Click();
            string pageUrl = chrome.Url;
            Assert.AreEqual(expextedUrl, pageUrl);
        }
        [Test(Description = "Сhecking of sending an empty newsletter subscription form")] 
        public void SendITSubscribeOnlySpaces()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/events/");

            IWebElement elementFieldEmail = chrome.FindElement(By.Id("blog_email"));
            elementFieldEmail.SendKeys(" ");

            IWebElement elementButtonSend = chrome.FindElement(By.Id("blog_btn"));
            bool actialResult = elementButtonSend.Enabled;

            Assert.AreEqual(false, actialResult);
        }
        [Test(Description = "When in header change language to en must navigate to page with English localization")] 
        public void ChangeLanguageToEn()
        {
            IWebElement elementClickAllLanguage = chrome.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > button"));
            elementClickAllLanguage.Click();

            IWebElement elementEnLanguage = chrome.FindElement(By.CssSelector("body > div.wrapper > div > header > div > div._header__lists > ul > li > ul > li:nth-child(2) > a"));
            elementEnLanguage.Click();

            string pageUrl = chrome.Url;
            Assert.AreEqual("https://deveducation.com/en/", pageUrl);
        }     

        [TestCase("https://deveducation.com/courses/", " li:nth-child(1) > a", Description = "Transition from the header in main menu to the page - Courses")]
        [TestCase("https://deveducation.com/graduates/", " li:nth-child(2) > a", Description = "Transition from the header in main menu to the page - Graduates")]
        public void GoToPageInHeaderFromMainMenu(string expectedUrl, string continuationSelector)
        {
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement elementPopup = chrome.FindElement(By.CssSelector("body > div.wrapper > main > div.popups.subscribe-pop.closing-pop.show > div > button"));
            elementPopup.Click();

            string selector = "body > div.wrapper > div > header > div > div._header__lists > nav > ul >" + continuationSelector;
            IWebElement element = chrome.FindElement(By.CssSelector(selector));
            element.Click();

            string pageUrl = chrome.Url;
            Assert.AreEqual(expectedUrl, pageUrl);
        }
        [Test(Description = "Check online certificate")]
        public void CertificateAuthentication()
        {
            chrome.Navigate().GoToUrl("https://dnipro.deveducation.com/courses/");

            IWebElement elementButtonCheck = chrome.FindElement(By.CssSelector("body > div.wrapper.sub > main > section.bridge2 > div > button"));
            elementButtonCheck.Click();

            IWebElement elementNumberCertificate = chrome.FindElement(By.CssSelector("#checker > div:nth-child(1) > input"));
            elementNumberCertificate.SendKeys("QAAT01 201902");

            IWebElement elementLastName = chrome.FindElement(By.CssSelector("#checker > div:nth-child(2) > input"));
            elementLastName.SendKeys("halchenko");

            IWebElement elementButtonSend = chrome.FindElement(By.CssSelector("#checker > div:nth-child(3) > button"));
            elementButtonSend.Click();

            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(25);

            IWebElement elementButtonOpenCertificate = chrome.FindElement(By.XPath("/html/body/div[2]/main/div[6]/div/div/div[2]/a"));
            elementButtonOpenCertificate.Click();

            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            string pageUrl = chrome.Url;
            Assert.AreEqual("https://deveducation.com/verify/?token=c0b33fa6d86c1cf1a18c373e02e56b5f", pageUrl);
        }
        [Test(Description = "Checking for the presence of an image (on the page https://kyiv.deveducation.com/courses/java/")]
        public void CheckDisplayedImg()
        {
            chrome.Navigate().GoToUrl("https://kyiv.deveducation.com/courses/java/");
            IWebElement elementImg = chrome.FindElement(By.CssSelector("body > div.wrapper.sub > main > section.about-course.section > img"));
            bool actialResult = elementImg.Displayed;
            Assert.AreEqual(true, actialResult);
        }

        [Test(Description = "Chek navigate to 404 page if url does not exist")]
        public void GoTo404()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            IWebElement element = chrome.FindElement(By.ClassName("title-404")); 
            string text = element.Text;
            Assert.AreEqual("404", text);
        }

        [Test(Description = "Year in footer must be actual")]
        public void FooterYear()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            IWebElement element = chrome.FindElement(By.ClassName("ofooter-year"));
            string text = element.Text;
            string year = DateTime.Now.Year.ToString();
            Assert.AreEqual(year, text);
        }       
        [SetUp]
        public void Start()
        {
            chrome = new ChromeDriver(@"D:\Proga\Курсы\HW14 Selenium\HW14_Selenium\packages\Selenium.WebDriver.ChromeDriver.85.0.4183.8700\driver\win32");
            chrome.Navigate().GoToUrl("https://deveducation.com/");
            chrome.Manage().Window.Maximize(); 
        }

        [TearDown]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }


}
