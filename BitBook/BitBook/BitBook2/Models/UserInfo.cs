using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBook2.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfilePhoto { get; set; }
        public string CoverPhoto { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}