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
        private IWebDriver _webDriver;

        [SetUp]
        public void StartBrowserChrome()
        {
            _webDriver = new ChromeDriver
            {
                Url = "https://skymann.com/waawo/?wurl=/orders_flights/enter_data/f84b9e1992/429f48260f3c13a487db348aa370bf817e4e033d"
            };
        }

        [Test]
        public void EmptyField()
        {
            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='waavoiframe0']"));
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(By.XPath("//*[@id='waavoiframe0']")));

            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='conditions']"));
            var conditionsCheckBox = _webDriver.FindElement(By.XPath("//*[@id='conditions']"));
            conditionsCheckBox.Click();

            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            var submitButton = _webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            submitButton.Click();

            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[1]/div/div"));
            var errorMessage = _webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[1]/div/div"));
            var isErrorMessageCorrect = errorMessage.Text.Equals("Введите имя, пожалуйста");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [Test]
        public void LongName()
        {
            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='waavoiframe0']"));
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(By.XPath("//*[@id='waavoiframe0']")));

            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='conditions']"));
            var conditionsCheckBox = _webDriver.FindElement(By.XPath("//*[@id='conditions']"));
            conditionsCheckBox.Click();

            var surnameInput = _webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsPassengers1Surname']"));
            surnameInput.SendKeys("CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK_CHUPAKABRIK_CHIKIBRYAK");

            var submitButton = _webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[5]/div/div/div[2]/button"));
            submitButton.Click();

            WaitForElementToAppear(_webDriver, 15, By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[2]/div/div"));
            var errorMessage = _webDriver.FindElement(By.XPath("//*[@id='OrdersFlightsEnterDataForm']/div[2]/div[2]/div[2]/div[2]/div/div"));
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
            _webDriver.Quit();
        }
    }
}