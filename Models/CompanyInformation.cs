using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class CompanyInformation
  {
    [Key]
    public int CompanyID { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Nullable<Boolean> IsActive { get; set; }
    public string Initials { get; set; }  

  }
}