using Framework.Services;
using GitHubAutomation.Utils;
using NUnit.Framework;
using PageObject.PageObjects;

namespace Framework.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        [Test]
        public void RussianWordInNameInput()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"RussianWordInNameInput\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, введите правильное имя", reservationPage.GetNameError());
            });
        }

        [Test]
        public void NoConditions()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"NoConditions\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnSubmitButton()
                    .SwitchToAlert(Driver);
                Assert.AreEqual("Примите наши условия, пожалуйста", reservationPage.Text);
            });
        }

        [Test]
        public void RussianWordInSecondNameInput()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"RussianWordInSecondNameInput\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, введите правильное имя", reservationPage.GetSurnameError());
            });
        }

        [Test]
        public void IncorrectEmail()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"IncorrectEmail\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите правильный электронный адрес, пожалуйста", reservationPage.GetEmailError());
            });
        }

        [Test]
        public void TooLongName()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"TooLongName\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Слишком длинное имя. Свяжитесь с нами по телефону", reservationPage.GetNameError());
            });
        }

        [Test]
        public void TooLongSurname()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"TooLongSurname\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Слишком длинная фамилия. Свяжитесь с нами по телефону", reservationPage.GetSurnameError());
            });
        }

        [Test]
        public void DontChooseGender()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseGender\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, выберите", reservationPage.GetGenderError());
            });
        }

        [Test]
        public void DontChooseName()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseName\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите имя, пожалуйста", reservationPage.GetNameError());
            });
        }

        [Test]
        public void DontChooseSurname()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseSurname\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите фамилию, пожалуйста", reservationPage.GetSurnameError());
            });
        }

        [Test]
        public void DontChooseEmail()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseEmail\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите правильный электронный адрес, пожалуйста", reservationPage.GetEmailError());
            });
        }
    }
}