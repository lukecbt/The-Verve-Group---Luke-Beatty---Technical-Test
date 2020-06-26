using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Verve_Group___Luke_Beatty.Controllers;
using The_Verve_Group___Luke_Beatty.Models;
using The_Verve_Group___Luke_Beatty.Models.ViewModels;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUser() // test to return the page with a user
        {
            // Test the returned view
            var controller = new HomeController();
            var result = controller.GetUser(new GetUserForm { Username = "robconery" }) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestGetUserDetails1() // test the user details returned (inc repo)
        {
            // Assuming Rob conery is the user searched
            GetUserForm form = new GetUserForm
            {
                Username = "robconery"
            };
            var controller = new HomeController();
            var result = controller.GetUser(form) as ViewResult;

            // Tests the details assuming rob conery is the user searched
            var user = (GithubUser)result.ViewData.Model;
            Assert.AreEqual("Rob Conery", user.Name);
            Assert.AreEqual("Honolulu, HI", user.Location);
            Assert.AreEqual("https://avatars0.githubusercontent.com/u/78586?v=4", user.Avatar_URL);
        }

        [TestMethod]
        public void TestGetUserDetails2() // test the user details returned
        {
            // Assuming lukecbt (me) is the user searched
            GetUserForm form = new GetUserForm
            {
                Username = "lukecbt"
            };
            var controller = new HomeController();
            var result = controller.GetUser(form) as ViewResult;

            // Tests the details assuming lukecbt (me) is the user searched
            var user = (GithubUser)result.ViewData.Model;
            Assert.AreEqual(null, user.Name);
            Assert.AreEqual("Newcastle Upon Tyne", user.Location);
            Assert.AreEqual("https://avatars0.githubusercontent.com/u/67437829?v=4", user.Avatar_URL);
        }

        [TestMethod]
        public void TestGetUserRepos() // test the user details returned (inc repo)
        {
            // Assuming Rob conery is the user searched
            GetUserForm form = new GetUserForm
            {
                Username = "robconery"
            };
            var controller = new HomeController();
            var result = controller.GetUser(form) as ViewResult;

            // Tests the details assuming rob conery is the user searched
            var user = (GithubUser)result.ViewData.Model;

            // Arrays containing the expected results from the returned users top repos (based on stargazers)
            var expectedName = new string[] {"azx", "knockout-cart", "mvcmusic", "moebius", "js-inferno" };
            var expectedFullName = new string[] { "robconery/azx", "robconery/knockout-cart", "robconery/mvcmusic", "robconery/moebius", "robconery/js-inferno" };
            var expectedDescription = new string[] { "Azure scripts made easy",
            "A simple browser-based shopping cart that uses local storage, powered by KnockoutJS",
            "Harder Faster Better Stronger",
            "A functional query tool for Elixir",
            "Code for the Javascript Inferno talk"};
            var expectedStargazers = new int[]{9, 82, 76, 523, 5 };
            var expectedUrl = new string[] { "https://github.com/robconery/azx",
            "https://github.com/robconery/knockout-cart",
            "https://github.com/robconery/mvcmusic",
            "https://github.com/robconery/moebius",
            "https://github.com/robconery/js-inferno"};

            // The actual results of the users repos
            var actualName = user.Repos.Select(x => x.Name).ToArray();
            var actualFullName = user.Repos.Select(x => x.Full_Name).ToArray();
            var actualDescription = user.Repos.Select(x => x.Description).ToArray();
            var actualStargazers = user.Repos.Select(x => x.Stargazers_Count).ToArray();
            var actualUrl = user.Repos.Select(x => x.Html_URL).ToArray();

            // Testing the expected outcome with the actual outcome for each field
            CollectionAssert.AreEqual(expectedName, actualName);
            CollectionAssert.AreEqual(expectedFullName, actualFullName);
            CollectionAssert.AreEqual(expectedFullName, actualDescription);
            CollectionAssert.AreEqual(expectedStargazers, actualStargazers);
            CollectionAssert.AreEqual(expectedUrl, actualUrl);
        }
    }
}
