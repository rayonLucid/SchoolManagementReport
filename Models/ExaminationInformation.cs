using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolManagementReport.Models
{

    public class ExaminationInformation
    {
    [Key]
    public string StudentID { get; set; }
    public string SubjectName { get; set; }
    public decimal MidTermScore { get; set; }
    public decimal ExamScore { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal TotalScore { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal AverageScore { get; set; }
    public string Remarks { get; set; }
    public string Session { get; set; }
    public int  ExamYear { get; set; } = DateTime.Now.Year;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
  }


}