using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.ViewModels
{
    public class UpdateAccountViewModel
    {
        public string Name { get; set; }
        public int Id {get; set;}
        public IdentityUpdateViewModel IdentityUpdate { get; set; }
        public string Description { get; set; }
        public string Expertise { get; set; }
        public string SocialLinks { get; set; }

    }

}