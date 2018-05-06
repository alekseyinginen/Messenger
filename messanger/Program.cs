using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.ApiClient;
using Messenger.ApiClient.Models;
using Messenger.Forms;

namespace Messenger
{
    static class Program
    {
        private static async Task<UserModel> GetCurrentUserFromApiAsync(MessengerApiClient apiClient)
        {
            UserModel user = await apiClient.GetCurrentUser();
            if (string.IsNullOrEmpty(user.Username)) 
            {
                return null;
            }
            return user;
        }

        private static UserModel GetCurrentUserFromApi(MessengerApiClient apiClient) 
        {
            var userTask = Task.Factory.StartNew(() => GetCurrentUserFromApiAsync(apiClient)).Result;

            return userTask.Result;
        }

        private static void ShowForm(Func<Form> GetForm) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GetForm());
        }

        [STAThread]
        static void Main()
        {
            //MessengerApiClient apiClient = MessengerApiClient.GetInstance();

            UserModel user = null;//GetCurrentUserFromApi(apiClient);

            if (user == null) 
            {
                ShowForm(() => new LoginForm(string.Empty, string.Empty));
            }
            else 
            {
                //TODO: client form
                ShowForm(() => new Form());
            }
        }
    }
}
