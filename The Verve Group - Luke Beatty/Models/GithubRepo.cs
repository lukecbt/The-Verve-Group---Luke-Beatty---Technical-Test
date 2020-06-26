using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The_Verve_Group___Luke_Beatty.Models
{
    public class GithubRepo
    {
        public string Name { get; set; }

        public string Full_Name { get; set; }

        public string Description { get; set; }

        public int Stargazers_Count { get; set; }

        public string Html_URL { get; set; }
    }
}