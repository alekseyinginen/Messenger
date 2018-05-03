using Messenger.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messenger.ApiClient.Helpers;

namespace Messenger.ApiClient
{
    public class MessengerApiClient
    {
        private static MessengerApiClient apiClient;

        private HttpClient client;
        private ModelBuilder modelBuilder;

        private MessengerApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:54419/");
            modelBuilder = new ModelBuilder();
        }

        public static MessengerApiClient GetInstance()
        {
            if (apiClient == null)
            {
                apiClient = new MessengerApiClient();
            }
            return apiClient;
        }

        public async Task<HttpResponseMessage> Login(string username, string password)
        {
            LoginModel model = modelBuilder.BuildLoginModel(username, password);
            var content = JsonFormatter.GetStringJsonContent(model);
            var response = await client.PostAsync(ApiRoutes.Login, content);
            return response;
        }

        public async Task<HttpResponseMessage> Logout()
        {
            return await client.GetAsync(ApiRoutes.Logout);
        }

        public async Task<HttpResponseMessage> Register(string username, string email, string pictureURL, string password)
        {
            RegisterModel model = modelBuilder.BuildRegisterModel(username, email, pictureURL, password);
            var content = JsonFormatter.GetStringJsonContent(model);
            return await client.PostAsync(ApiRoutes.Regiser, content);
        }

        public async Task<UserModel> GetCurrentUser()
        {
            var response = await client.GetAsync(ApiRoutes.CurrentUser);
            string json = await response.Content.ReadAsStringAsync();
            return JsonFormatter.Deserialize<UserModel>(json);
        }
    }
}
