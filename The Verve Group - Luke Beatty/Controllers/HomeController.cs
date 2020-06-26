using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using The_Verve_Group___Luke_Beatty.Helpers;
using The_Verve_Group___Luke_Beatty.Models;
using The_Verve_Group___Luke_Beatty.Models.ViewModels;

namespace The_Verve_Group___Luke_Beatty.Controllers
{
    public class HomeController : Controller
    {
        private const string GithubApiUrl = "https://api.github.com/users/{username}";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Render the get user form
        public ActionResult RenderForm()
        {
            var vm = new GetUserForm();
            return PartialView("GetUserFormPartial", vm);
        }

        // Submit the form and get said github user
        public ActionResult GetUser(GetUserForm model)
        {
            TempData["Submitted"] = true; // mark form as submitted

            // Create the api url for getting the user
            string url = GithubApiUrl.Replace("{username}", model.Username);

            ApiHelper apiHelper = new ApiHelper();
            // Pass api url into helper method to get the api results then conver to the Github user model
            var user = apiHelper.GetResultFromApi<GithubUser>(url);

            // Order by stargazers descending to get the top 5 and get the first 5 elements
            user.Repos = apiHelper.GetResultFromApiEnum<GithubRepo>(user.Repos_URL).OrderByDescending(x => x.Stargazers_Count).Take(5).ToList();

            return View("Index", user); // return view with user model
        }
    }
}