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
        public void ShouldReturnSomethingValidWhenMakingARequestToGithubApi()
        {
            var request = WebRequest.Create("https://github.com/api/v2/json/user/search/robertgreiner") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
