using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiplexBookingWebAPI.Models
{
    public class MultiplexLoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
       // public string Token { get; set; }

    }
}