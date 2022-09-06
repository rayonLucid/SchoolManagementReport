using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementReport.Models
{

[Table("EmployeesInformation")]
     public class EmployeesInformation
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeesID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string ImageName  { get; set; }

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; }
        public string PhysicalAddresses { get; set; } = string.Empty;

         public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string JobPosition { get; set; } = string.Empty;

         public string SubjectTeacher { get; set; } = string.Empty;
        public string ClassTeacher { get; set; } = string.Empty;

         public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
