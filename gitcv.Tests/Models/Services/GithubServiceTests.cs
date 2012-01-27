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
        public void ShouldReturnUserLoginNamet()
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
