using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementReport.Models
{
    public class SessionsInformation
    {
        [Key]
        public string  AcademicYear { get; set; }
          public bool CurrentSession { get; set; }
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int RowID { get; set; }
          public int StudentNo { get; set; }

  }
}