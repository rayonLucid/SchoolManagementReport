using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementReport.Models
{
    public class UserInformation
    {[Key]
        public string UserID { get; set; }
    public string Phone { get; set; }
    public string AdmissionID { get; set; }
    public string ImageUrl { get; set; }
    public string BloodGroup { get; set; }
    public string FirstName { get; set; } = string.Empty;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RowID { get; set; }

    public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
         public string ResidentialAddress { get; set; } = string.Empty;

         public string CurrentClass { get; set; }
        public string PreviousClass { get; set; }
    public string Gender { get; set; }  = string.Empty;
    public string SessionAdmitted { get; set; }
    public Nullable<DateTime> DateAdmitted { get; set; }
    public string ParentID { get; set; }

    public string SubjectTeacher { get; set; } = string.Empty;
    public string ClassTeacher { get; set; } = string.Empty;

    public Nullable<Boolean> IsSubjectTeacher { get; set; } 
    public Nullable<Boolean> IsClassTeacher { get; set; } 
    public string Designation { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }
    //public Nullable<DateTime> EnteredDate { get; set; }
    public string CompanyName { get; set; }
    public Nullable<Boolean> IsActive { get; set; }
  }
}