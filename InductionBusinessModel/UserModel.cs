using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InductionDAL;
namespace InductionBusinessModel
{
    public class UserModel
    {
        DatabaseHandler objDb = new DatabaseHandler();

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string UserPId { get; set; }
        public int RoleId { get; set; }
        public string HashPassword { get; set; }
        public bool isPasswordExpired { get; set; }
        public DateTime PasswordUpdatedOn { get; set; }

        public UserModel()
        {
            //int result = objDb.ExecuteNonQuery("select * from appuser");
            //objDb.GetDataTable("select * from appuser");

        }
        public bool AuthenticateUser(string loginid, string pswd)
        {
            bool isValid = false;
            int result = objDb.ExecuteNonQuery("select 1 from appuser where email='" + loginid + "' and HashPassword='" + pswd + "' and isPasswordExpired=0");
            if (result > 0)
                isValid = true;
            return isValid;
        }
    }
}
