using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using System.Runtime.Serialization.Json;
using gitcv.Models.Types;

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
}
