using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gitcv.Models.Services;
using gitcv.Models.Types;

namespace gitcv.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string loginName)
        {
            var user = new GithubUser();
            var repos = new List<GithubRepository>();

            try
            {
                user = GithubService.GetUser(loginName);
                repos = GithubService.GetRepositories(loginName);
            }
            catch
            {
            }

            ViewBag.User = user;
            ViewBag.Repositories = repos;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return new RedirectResult(collection["loginName"]);
        }

    }
}
