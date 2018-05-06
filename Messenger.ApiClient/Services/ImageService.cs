using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ApiClient.Services 
{
    public class ImageService 
    {
        public Stream DownloadImage(string url) 
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }
    }
}
