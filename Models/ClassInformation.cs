using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class ClassInformation
    {
    [Key]
    public int ClassID { get; set; }
    public string Name { get; set; }
    public string Teacher { get; set; }
    public int Population { get; set; }
    public string ClassLevel { get; set; }  
  }
}