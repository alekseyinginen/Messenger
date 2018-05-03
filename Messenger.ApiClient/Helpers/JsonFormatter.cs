using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Messenger.ApiClient.Helpers
{
    public static class JsonFormatter
    {
        public static string Serialize<T>(T item) where T : class
        {
            return JsonConvert.SerializeObject(item);
        }

        public static T Deserialize<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static StringContent GetStringJsonContent<T>(T item) where T : class
        {
            string json = Serialize(item);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
