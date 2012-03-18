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
        public ActionResult Index()
        {
            return View();         
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var loginName = collection["loginName"];

            if (String.IsNullOrEmpty(loginName))
            {
                ViewBag.ErrorMessage = "Please enter a github username.";
                return View("Index");
            }

            return new RedirectResult(loginName);
        }

        public ActionResult Results(string loginName)
        {
            var user = new GithubUser();
            var languages = new Dictionary<string, int>();
            var repos = new List<GithubRepository>();

            try
            {
                user = GithubService.GetUser(loginName);
                languages = GithubService.GetLanguages(loginName);
                repos = GithubService.GetRepositories(loginName);
                repos.Sort((x, y) => String.CompareOrdinal(x.name, y.name));
            }
            catch
            {
                ViewBag.ErrorMessage = "Sorry, that user doesn't exist on Github, please try again.";
                return View("Index");  
            }
            
            ViewBag.User = user;
            ViewBag.Repositories = repos;
            ViewBag.OriginalRepositories = repos.Where(r => r.fork == false);
            ViewBag.ForkedRepositories = repos.Where(r => r.fork == true);
            ViewBag.Languages = languages;

            return View();
        }
 
    }
}
