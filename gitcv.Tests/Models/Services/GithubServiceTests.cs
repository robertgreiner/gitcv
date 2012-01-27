using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using System.Runtime.Serialization.Json;

namespace gitcv.Tests.Models.Services
{
    [TestFixture]
    class GithubServiceTests
    {

        [Test]
        public void ShouldReturnUserSpecificContentOnValidGithubUsername()
        {
            var request = WebRequest.Create("https://api.github.com/users/robertgreiner") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            response.Close();
            Assert.IsTrue(response.ContentLength > 12);
        }

        [Test]
        public void ShouldReturnGithubUsernameWithBasicGithubUserSearch()
        {
            var request = WebRequest.Create("https://api.github.com/users/robertgreiner") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            var receiveStream = response.GetResponseStream();
            var readStream = new StreamReader(receiveStream, Encoding.UTF8);
            var stream = readStream.ReadToEnd();
            response.Close();   
            Assert.IsTrue(stream.Contains("\"login\":\"robertgreiner\""));
        }

        [Test]
        public void ShouldReturnPublicRepoCount()
        {
            var request = WebRequest.Create("https://api.github.com/users/robertgreiner") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            var receiveStream = response.GetResponseStream();

            var serializer = new DataContractJsonSerializer(typeof(GithubUser));
            var user = (GithubUser) serializer.ReadObject(receiveStream);

            Assert.AreEqual("robertgreiner", user.login);

            response.Close();
        }
    }

    public class GithubUser
    {
        public String login { get; set; }
        public String id { get; set; }
        public String avatar_url { get; set; }
        public String gravatar_id { get; set; }
        public String url { get; set; }
        public String name { get; set; }
        public String company { get; set; }
        public String blog { get; set; }
        public String location { get; set; }
        public String email { get; set; }
        public String hireable { get; set; }
        public String bio { get; set; }
        public String public_repos { get; set; }
        public String public_gists { get; set; }
        public String followers { get; set; }
        public String following { get; set; }
        public String html_url { get; set; }
        public String created_at { get; set; }
        public String type { get; set; }
    }
}
