using Framework.Services;
using GitHubAutomation.Utils;
using NUnit.Framework;
using PageObject.PageObjects;

namespace Framework.Tests
{
    [TestFixture]
    [Category("All")]
    public class WebTests : GeneralConfig
    {
        [Test]
        [Category("RussianWords")]
        public void RussianWordInNameInput()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"RussianWordInNameInput\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUserForRussianWordsCategory())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, введите правильное имя", reservationPage.GetNameError().Text);
            });
        }

        [Test]
        [Category("DontChoose")]
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
        [Category("RussianWords")]
        public void RussianWordInSurnameInput()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"RussianWordInSurnameInput\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUserForRussianWordsCategory())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Слишком длинное имя/фамилия. Свяжитесь с нами по телефону", reservationPage.GetSurnameError().Text);
            });
        }

        [Test]
        [Category("IncorrectEmail")]
        public void IncorrectEmail()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"IncorrectEmail\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите правильный электронный адрес, пожалуйста", reservationPage.GetEmailError().Text);
            });
        }

        [Test]
        [Category("TooLong")]
        public void TooLongName()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"TooLongName\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUserForTooLongCategory())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, введите правильное имя", reservationPage.GetNameError().Text);
            });
        }

        [Test]
        [Category("TooLong")]
        public void TooLongSurname()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"TooLongSurname\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUserForTooLongCategory())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Слишком длинное имя/фамилия. Свяжитесь с нами по телефону", reservationPage.GetSurnameError().Text);
            });
        }

        [Test]
        [Category("DontChoose")]
        public void DontChooseGender()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseGender\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Пожалуйста, выберите", reservationPage.GetGenderError().Text);
            });
        }

        [Test]
        [Category("DontChoose")]
        public void DontChooseName()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseName\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите имя, пожалуйста", reservationPage.GetNameError().Text);
            });
        }

        [Test]
        [Category("DontChoose")]
        public void DontChooseSurname()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseSurname\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите фамилию, пожалуйста", reservationPage.GetSurnameError().Text);
            });
        }

        [Test]
        [Category("DontChoose")]
        public void DontChooseEmail()
        {
            SaveScreenshotOnTestFailure(() =>
            {
                Logger.Log.Info("Start \"DontChooseEmail\" test");
                var reservationPage = new ReservationPage(Driver)
                    .ClickOnConditionsCheckBox()
                    .FillUserData(UserDataCreator.FillUser())
                    .ClickOnSubmitButton();
                Assert.AreEqual("Введите правильный электронный адрес, пожалуйста", reservationPage.GetEmailError().Text);
            });
        }
    }
}