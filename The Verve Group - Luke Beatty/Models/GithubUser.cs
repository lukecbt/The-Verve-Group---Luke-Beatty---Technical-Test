using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The_Verve_Group___Luke_Beatty.Models
{
    public class GithubUser
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Avatar_URL { get; set; }

        public string Repos_URL { get; set; }

        public ICollection<GithubRepo> Repos { get; set; }
    }
}