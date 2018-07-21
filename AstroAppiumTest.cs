using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AstroAppiumTest
{
    [TestClass]
    public class AstroAppiumTest
    {
        private AppiumDriver<AndroidElement> driver;

        [TestMethod]
        public void AppiumTest()
        {

            //set the capabilities
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName","trputtap");
            cap.SetCapability("platformVersion","6.0.0");
            cap.SetCapability("udid","169.254.76.233:5555");
            cap.SetCapability("fullreset","true");
            cap.SetCapability(MobileCapabilityType.App,"Browser");
            cap.SetCapability("platformName","Android");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"),cap);

            //Navigate to Browser
            driver.Navigate().GoToUrl("https://www.astro.com.my");

            var loginButton = driver.FindElementById("acmlogin");
            loginButton.Click(); 
            driver.FindElementById("body_txtAstroID").SendKeys("thejdeep.p@gmail.com");
            driver.FindElementById("body_txtPassword").SendKeys("12345Reddy"); 
            driver.FindElementById("ctl00$body$btnLogin").Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElementById("body_Mustwatchastro").Click();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElementById("results_2").Click();
            var synopsisText = driver.FindElementByCssSelector(".span > result").Text;

            if (synopsisText.Length > 50)
            {
                Console.WriteLine(" Synopsis text is more than 50 Characters");
            }

            driver.FindElementById("reaminder_user").Click();
            var favourites = driver.FindElementByCssSelector(".user > a");
            Actions actions = new Actions(driver);
            actions.MoveToElement(favourites).Perform();
            driver.FindElementById("remove_show").Click();
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Console.WriteLine(" Test Executed for Appium Astro Test");
            driver.Quit();

        }
    }
}
