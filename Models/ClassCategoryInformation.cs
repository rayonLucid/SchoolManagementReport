using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class ClassCategoryInformation
    {[Key]

        
        public int ID { get; set; }
        public string ClassCategory { get; set; } = string.Empty;
        public string ClassLevel { get; set; } = string.Empty;
 

  }
}