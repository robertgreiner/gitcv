using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using gitcv.Models.Types;

namespace gitcv.Models.Services
{
    public class GithubService
    {
        public GithubService()
        {
            
        }

        public static GithubUser GetBasicUserInformation(string userName)
        {
            var uri = string.Format("https://api.github.com/users/{0}", userName);
            var stream = MakeRequest(uri);
            var serializer = new DataContractJsonSerializer(typeof(GithubUser));
            var user = (GithubUser)serializer.ReadObject(stream);
            stream.Close();
            return user;
        }

        private static Stream MakeRequest(string uri)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            return response.GetResponseStream();
        }
    }
}