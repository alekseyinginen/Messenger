using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ApiClient.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string PictureURL { get; set; }

        public List<string> Roles { get; set; }
    }
}
