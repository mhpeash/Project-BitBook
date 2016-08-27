using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BitBook2.Models
{
    public class AllStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}