using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class SubjectTeacherInformation
    {
    [Key]
    public int  ID { get; set; }
   
    public string SubjectTeacher { get; set; }
    public string ClassLevel { get; set; }
    public string ClassCategory { get; set; }
    public string  SubjectName { get; set; }= string.Empty;
    }
} 