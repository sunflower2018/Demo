using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebApi.Models
{
    public class LoginToken
    {
        public int userid { get; set; }
        public string loginname { get; set; }
        public string username { get; set; }
    }
}