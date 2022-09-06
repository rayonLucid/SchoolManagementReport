using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolManagementReport.Models
{
    public class SubjectLevelInformation
{
               [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ID { get; set; }



    public string ClassLevel { get; set; } = string.Empty;

        public string SubjectName { get; set; } = string.Empty;
    public string ClassCategory { get; set; } = string.Empty;
  }
}