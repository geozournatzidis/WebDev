using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorSyntaxFrontEnd.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }

        public UserModel(string name, string emailAdress, string phoneNumber)
        {
            Name = name;
            EmailAdress = emailAdress;
            PhoneNumber = phoneNumber;
        }
    }
}