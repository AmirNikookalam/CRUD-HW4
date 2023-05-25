using System.Data;

namespace HW4.Entities
{
    public class User
    {
        public int userID { get; set; }
        public string? userName { get; set; }
        public string? userMobileNumber { get; set; }
        public DateTime userBirthday { get; set; }
        public DateTime userDateCreated { get; set; }

        public bool DateTimeIsValid (DateTime dateTime)
        { 
            return dateTime.CompareTo (DateTime.Now) <= 0;
        }

        public bool MobileNumberIsValid (string? mobileNumber)
        {
            return mobileNumber.Count() == 11;
        }
    }
}
