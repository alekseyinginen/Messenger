using System.Collections.Generic;

namespace Messenger.ApiClient.Models
{
    public class GroupModel
    {
        public string GroupId { get; set; }

        public List<string> Usernames { get; set; }
    }
}
