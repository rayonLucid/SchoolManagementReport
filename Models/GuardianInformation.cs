using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class GuardianInformation
    {[Key]

        public int ParentID { get; set; }
        public string FirstName { get; set; } = string.Empty;


        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string Addresses { get; set; } = string.Empty;

         public int PhoneNumber { get; set; }

        public string Occupation { get; set; } = string.Empty;

         public string SubjectTeacher { get; set; } = string.Empty;
        public string ClassTeacher { get; set; } = string.Empty;

         public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}