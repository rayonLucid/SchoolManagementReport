using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementReport.Models
{
    public class TermsInformation
    {[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string Term { get; set; } = string.Empty;
        public bool CurrentTerm { get; set; }

    }
}