using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject.PageObjects
{
    public class ReservationPage
    {
        private readonly IWebDriver driver;

        public IWebElement conditionsCheckBox => GetElement("//*[@id='conditions']");

        public IWebElement nameInput => GetElement("//*[@id='OrdersFlightsPassengers1Name']");

        public IWebElement submitButton => GetElement("//button[@class='btn btn-success btn-lg ladda-button']");

        public ReservationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WaitForElementToAppear(driver, 15, By.XPath("//*[@id='waavoiframe0']"));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='waavoiframe0']")));
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 15, By.XPath(xPath));

            return driver.FindElement(By.XPath(xPath));
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        public IAlert SwitchToAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert;
        }

        public IWebElement GetNameError()
        {
            return GetElement("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[1]/div/div");
        }
    }
}