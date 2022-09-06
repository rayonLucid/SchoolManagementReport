using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementReport.Models
{
    public class Notifications
  {
    [Key]
    public int ID { get; set; }
    public string Narrative { get; set; }
    public string Signatory { get; set; }
    public Nullable<DateTime> StartDate { get; set; }
    public Nullable<DateTime> EndDate { get; set; }
    public Nullable<DateTime> PostedDate { get; set; }
    public Nullable<Boolean> Posted { get; set; }
  }
}