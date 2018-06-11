using Messenger.ApiClient.Helpers;
using Messenger.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Messenger.ApiClient
{
    public class MessengerApiClient
    {
        private static MessengerApiClient apiClient;

        private HttpClient client;
        private ModelBuilder modelBuilder;

        private MessengerApiClient()
        {
            string baseAddress = ConfigurationManager.AppSettings.Get("ApiBaseAddress");
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
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

        public async Task<MessageModel> AddMessage(MessageModel model)
        {
            //var content = JsonFormatter.GetStringJsonContent(model);
            //var response = await client.PostAsync(ApiRoutes.AddMessage, content);
            //string json = await response.Content.ReadAsStringAsync();
            //return JsonFormatter.Deserialize<MessageModel>(json);

            throw new NotImplementedException();
        }

        public async Task<List<MessageModel>> GetMessages(string groupId)
        {
            var response = await client.GetAsync(ApiRoutes.AllGroupMessages + groupId);
            string json = await response.Content.ReadAsStringAsync();
            return JsonFormatter.Deserialize<List<MessageModel>>(json);
        }

        public async Task<List<UserModel>> SearchForUsers(string query)
        {
            var response = await client.GetAsync(ApiRoutes.SearchForUsers + query);
            string json = await response.Content.ReadAsStringAsync();
            return JsonFormatter.Deserialize<List<UserModel>>(json);
        }

        public async Task<GroupModel> CreateGroup(GroupModel group)
        {
            var content = JsonFormatter.GetStringJsonContent(group);
            var response = await client.PostAsync(ApiRoutes.CreateGroup, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonFormatter.Deserialize<GroupModel>(json);
            }
            return null;
        }

        public async Task<List<GroupModel>> GetAllUserGroups()
        {
            var response = await client.GetAsync(ApiRoutes.GetAllUserGroups);
            string json = await response.Content.ReadAsStringAsync();
            return JsonFormatter.Deserialize<List<GroupModel>>(json);
        }
    }
}
