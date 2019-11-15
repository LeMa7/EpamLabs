using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.PageObjects;

namespace PageObject.Tests
{
    [TestFixture]
    public class SkymannTests
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowserChrome()
        {
            driver = new ChromeDriver
            {
                Url = "https://skymann.com/waawo/?wurl=/orders_flights/enter_data/f84b9e1992/429f48260f3c13a487db348aa370bf817e4e033d"
            };
        }

        [Test]
        public void RussianWordInNameInput()
        {
            var reservationPage = new ReservationPage(driver);
            reservationPage.conditionsCheckBox.Click();

            reservationPage.nameInput.SendKeys("Чикибряк");
            reservationPage.submitButton.Click();

            var isErrorMessageCorrect = reservationPage.GetNameError().Equals("Пожалуйста, введите правильное имя");
            var a = reservationPage.GetNameError();
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [Test]
        public void NoConditions()
        {
            var reservationPage = new ReservationPage(driver);

            reservationPage.submitButton.Click();

            IAlert alert = reservationPage.SwitchToAlert(driver);

            var isErrorMessageCorrect = alert.Text.Equals("Примите наши условия, пожалуйста");
            Assert.IsTrue(isErrorMessageCorrect);
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}