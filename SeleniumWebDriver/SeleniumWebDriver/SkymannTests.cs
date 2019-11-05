using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriver
{
    [TestFixture]
    class SkymannTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void StartBrowserChrome()
        {
            webDriver = new ChromeDriver
            {
                Url = "https://skymann.com/waawo/?wurl=/orders_flights/enter_data/f84b9e1992/429f48260f3c13a487db348aa370bf817e4e033d"
            };
        }

        [Test]
        public void EmptyField()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='waavoiframe0']"));
            webDriver.SwitchTo().Frame(webDriver.FindElement(By.XPath("//*[@id='waavoiframe0']")));

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='conditions']"));
            var conditionsCheckBox = webDriver.FindElement(By.XPath("//*[@id='conditions']"));
            conditionsCheckBox.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            var submitButton = webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            submitButton.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[1]/div/div"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[1]/div/div"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("Введите имя, пожалуйста");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [Test]
        public void LongName()
        {
            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='waavoiframe0']"));
            webDriver.SwitchTo().Frame(webDriver.FindElement(By.XPath("//*[@id='waavoiframe0']")));

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='conditions']"));
            var conditionsCheckBox = webDriver.FindElement(By.XPath("//*[@id='conditions']"));
            conditionsCheckBox.Click();

            var surnameInput = webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsPassengers1Surname']"));
            surnameInput.SendKeys("CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK");

            var submitButton = webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            submitButton.Click();

            WaitForElementToAppear(webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[2]/div/div"));
            var errorMessage = webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[2]/div/div"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("Слишком длинное имя/фамилия. Свяжитесь с нами по телефону");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }
    }
}