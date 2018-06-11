using Microsoft.AspNet.SignalR.Client;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Messenger.SignalRClient
{
    public class HubClient
    {
        private readonly HubConnection hubConnection;
        private readonly Action<string, object> callbackFunc;
        private IHubProxy hubProxy;

        public HubClient(Action<string, object> callbackFunc)
        {
            var signalRBaseAddress = ConfigurationManager.AppSettings.Get("SignalRBaseAddress");

            this.hubConnection = new HubConnection(signalRBaseAddress);
            this.callbackFunc = callbackFunc;
        }

        public async Task StartHub(string userId)
        {
            hubProxy = hubConnection.CreateHubProxy("ChatHub");

            await hubConnection.Start();

            await hubProxy.Invoke("Connect", userId);

            ConfigureCallback();
        }

        public async Task SendMessage(string message, string groupId)
        {
            await hubProxy.Invoke("SendMessage", message, groupId);
        }

        public async Task Disconnect()
        {
            await hubProxy.Invoke("Disconnect");

            hubConnection.Stop();
        }

        private void ConfigureCallback()
        {
            hubProxy.On<object>("addMessage", (data) => callbackFunc("addMessage", data));

            hubProxy.On<object>("userConnected", (data) => callbackFunc("userConnected", data));

            hubProxy.On<object>("userDisconnected", (data) => callbackFunc("userDisconnected", data));
        }
    }
}
