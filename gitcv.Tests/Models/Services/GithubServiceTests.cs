using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace gitcv.Tests.Models.Services
{
    [TestFixture]
    class GithubServiceTests
    {
        [Test]
        public void ShouldReturnEmptyContentOnInvalidGithubUsername()
        {
            var request = WebRequest.Create("https://github.com/api/v2/json/user/search/alksjhflakjsflkajsflkajsa12476214") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            response.Close();
            Assert.AreEqual(12, response.ContentLength);
        }

        [Test]
        public void ShouldReturnUserSpecificContentOnValidGithubUsername()
        {
            var request = WebRequest.Create("https://github.com/api/v2/json/user/search/robertgreiner") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            response.Close();
            Assert.IsTrue(response.ContentLength > 12);
        }
    }
}
