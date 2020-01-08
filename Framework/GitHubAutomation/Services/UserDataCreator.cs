using System;
using System.Text;
using Framework.Models;

namespace Framework.Services
{
    class UserDataCreator
    {
       public static UserData FillUser()
       {
            return new UserData(TestDataReader.GetTestData("UserName"), TestDataReader.GetTestData("UserSurname"), TestDataReader.GetTestData("Email"));
       }

        public static UserData FillUserForTooLongCategory()
        {
            return new UserData(TestDataReader.GetTestData("UserNameTooLong"), TestDataReader.GetTestData("UserSurnameTooLong"), TestDataReader.GetTestData("Email"));
        }

        public static UserData FillUserForRussianWordsCategory()
        {
            return new UserData(TestDataReader.GetTestData("UserNameRussianWords"), TestDataReader.GetTestData("UserSurnameRussianWords"), TestDataReader.GetTestData("Email"));
        }

        public static UserData FillUserForIncorrectEmailCategory()
        {
            return new UserData(TestDataReader.GetTestData("UserName"), TestDataReader.GetTestData("UserSurname"), TestDataReader.GetTestData("IncorrectEmail"));
        }
    }
}