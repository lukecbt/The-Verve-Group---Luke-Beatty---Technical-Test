using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace The_Verve_Group___Luke_Beatty.Models.ViewModels
{
    public class GetUserForm
    {
        [Required]
        public string Username { get; set; }
    }
}