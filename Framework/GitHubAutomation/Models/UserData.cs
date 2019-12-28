using System;
using System.Text;


namespace Framework.Models
{
    public class UserData
    {
        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string Email { get; set; }

        public UserData(string username, string userSurname, string email)
        {
            UserName = username;
            UserSurname = userSurname;
            Email = email;
        }
    }
}