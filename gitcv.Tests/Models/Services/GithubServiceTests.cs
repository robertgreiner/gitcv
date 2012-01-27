using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using gitcv.Models.Services;

namespace gitcv.Tests.Models.Services
{
    [TestFixture]
    class GithubServiceTests
    {
        [Test]
        public void ShouldReturnUserLoginName()
        {
            var user = GithubService.GetBasicUserInformation("robertgreiner");
            Assert.AreEqual("robertgreiner", user.login);
        }
    }
}
