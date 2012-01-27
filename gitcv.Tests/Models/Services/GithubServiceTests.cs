using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using gitcv.Models.Services;
using gitcv.Models.Types;

namespace gitcv.Tests.Models.Services
{
    [TestFixture]
    class GithubServiceTests
    {
        [Test]
        public void ShouldReturnUserLoginName()
        {
            var user = GithubService.GetUser("robertgreiner");
            Assert.AreEqual("robertgreiner", user.login);
        }

        [Test]
        public void ShouldReturnRepositoryInformation()
        {
            var repos = GithubService.GetRepositories("robertgreiner");
            Assert.IsNotEmpty(repos.First().clone_url);
            Assert.AreEqual("robertgreiner", repos.First().owner.login);
        }
    }
}
