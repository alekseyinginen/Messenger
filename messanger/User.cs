using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Messenger
{
    class User
    {
        private string Nick { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

        public User(string Nick, string Email, string Password)
        {
            this.Nick = Nick;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
