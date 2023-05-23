using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Entities
{
    public class User
    {
        public int userID {get; set;}
        public string? userName { get; set;}
        public string? userMobileNumber { get; set;}
        public DateTime userBirthday { get; set;}
        public DateTime userDateCreated { get; set; }
    }
}
