using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolManagementReport.Models
{
    public class SubjectInformation
{
                 [Key]
        public int ID { get; set; }
        public string SubjectName { get; set; } = string.Empty;


        public string ClassLevel { get; set; } = string.Empty;
    public string ClassCategory { get; set; } = string.Empty;

   // public string SubjectTeacher { get; set; } = string.Empty;
}
}