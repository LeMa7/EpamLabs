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
    }
}