using Messenger.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ApiClient.Helpers
{
    public class ModelBuilder
    {
        public LoginModel BuildLoginModel(string username, string password)
        {
            return new LoginModel
            {
                Username = username,
                Password = password
            };
        }

        public RegisterModel BuildRegisterModel(string username, string email, string pictureURL, string password)
        {
            return new RegisterModel
            {
                Username = username,
                Password = password,
                Email = email,
                PictureURL = pictureURL
            };
        }
    }
}
