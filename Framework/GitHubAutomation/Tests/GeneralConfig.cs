using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using Framework.Driver;
using GitHubAutomation.Utils;

namespace Framework.Tests
{
    public class GeneralConfig
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetDriver()
        {
            Logger.InitLogger();
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://skymann.com/waawo/?wurl=/orders_flights/enter_data/f84b9e1992/429f48260f3c13a487db348aa370bf817e4e033d");
        }

        protected void SaveScreenshotOnTestFailure(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                var screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                throw;
            }

        }

        [TearDown]
        public void QuitDriver()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
