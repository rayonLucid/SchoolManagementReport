using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class ClassLevelInformation
    {[Key]

        
        public int LevelID { get; set; }
        public string CLassLevel { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
 

  }
}