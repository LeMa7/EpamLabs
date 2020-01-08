using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObject.PageObjects
{
    public class ReservationPage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='conditions']")]
        public IWebElement conditionsCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='OrdersFlightsPassengers1Name']")]
        public IWebElement nameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='OrdersFlightsPassengers1Surname']")]
        public IWebElement surnameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='OrdersFlightsEmail']")]
        public IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success btn-lg ladda-button']")]
        public IWebElement submitButton;


        public ReservationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WaitForElementToAppear(driver, 15, By.XPath("//*[@id='waavoiframe0']"));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='waavoiframe0']")));
            WaitForElementToAppear(driver, 15, By.XPath("//*[@id='conditions']"));
            WaitForElementToAppear(driver, 15, By.XPath("//button[@class='btn btn-success btn-lg ladda-button']"));
            Thread.Sleep(10000);
        }

        public IWebElement GetElement(string xPath)
        {
            WaitForElementToAppear(driver, 20, By.XPath(xPath));

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

        public IWebElement GetSurnameError()
        {
            return GetElement("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[2]/div/div");
        }

        public IWebElement GetEmailError()
        {
            return GetElement("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[3]/div[1]/div/div");
        }

        public IWebElement GetGenderError()
        {
            return GetElement("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[1]/div[4]");
        }

        public ReservationPage ClickOnConditionsCheckBox()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            conditionsCheckBox.Click();
            return this;
        }

        public ReservationPage FillUserData(UserData userData)
        {
            nameInput.SendKeys(userData.UserName);
            surnameInput.SendKeys(userData.UserSurname);
            emailInput.SendKeys(userData.Email);
            return this;
        }

        public ReservationPage ClickOnSubmitButton()
        {
            Thread.Sleep(5000);
            submitButton.Click();
            return this;
        }
    }
}