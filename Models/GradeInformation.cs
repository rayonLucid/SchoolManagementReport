using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementReport.Models
{
    public class GradeInformation
    {[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string Grade { get; set; }
        public decimal LowerBoundary { get; set; }
    public decimal HighBoundary { get; set; }

  }
}