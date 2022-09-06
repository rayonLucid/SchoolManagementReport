using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
    public partial class StudentAdmissionForm : System.Web.UI.Page
    {
		public string AdmissionID { get; set; }
		public int studentno { get; set; }
		public CompanyInformation Company { get; set; }
		public SessionsInformation CurrenAccademicYear { get; set; }

		DbConnectContext db = new DbConnectContext();
    protected void Page_Load(object sender, EventArgs e)
        {
			SuccessLbl.Text = "";
			if (Session["Designation"] != null)
			{
				 Company = db.Company.FirstOrDefault();
				CurrenAccademicYear =db.Session.Where(x=>x.CurrentSession==true).FirstOrDefault();
				 studentno = CurrenAccademicYear.StudentNo + 1;
			 AdmissionID = Company.Initials + studentno.ToString() + CurrenAccademicYear.AcademicYear;
				string Target = Request.Form["Save"];
				if (Target == "SaveRecord")
				{
					SaveStudent();
				}
			}
			else { Response.Redirect("./Default.aspx"); }
		}

		private void SaveStudent()
		{
			string FirstName = Request.Form["FirstName"];
			string LastName = Request.Form["LastName"];
			string MiddleName = Request.Form["MiddleName"];
			string AdmissionID = Request.Form["AdmissionID"];
			string Phone = Request.Form["Phone"];
			string ParentName = Request.Form["ParentName"];
			string CurrentClass = Request.Form["CurrentClass"];
			string SessionAdmitted = Request.Form["SessionAdmitted"];
			string Email = Request.Form["Email"];
			string CurrentLevel = Request.Form["CurrentLevel"];
			DateTime  Admissiondate = DateTime.Parse(Request.Form["Admissiondate"]);
			DateTime DOB = DateTime.Parse(Request.Form["DOB"]);
			string bloodgroup = Request.Form["bloodgroup"];
			string Gender = Request.Form["Gender"];
			string UploadedFile = Request.Form["UploadedFile"];
			string UserName = Request.Form["UserName"];
			
			var Query = db.Users.FirstOrDefault(x => x.UserID == UserName);
			if (Query == null){
				UserInformation info = new UserInformation();

				info.Designation = "Student";
				info.DOB = DOB;
				info.Email = Email;
				info.FirstName = FirstName;
				info.Phone =Phone;
				info.LastName = LastName;
				
					info.IsActive = true;
				
				info.ClassTeacher = "";

				info.SessionAdmitted = SessionAdmitted;
				info.UserID =FirstName;
				info.Password = Guid.NewGuid().ToString();
				info.AdmissionID = AdmissionID;
				info.Gender = Gender;
				info.ImageUrl = UploadedFile;
					info.BloodGroup = bloodgroup;
				

				if (string.IsNullOrEmpty(Admissiondate.ToString()))
				{
					info.DateAdmitted = DateTime.Parse("1900-01-01");
				}
				else
				{
					info.DateAdmitted = Admissiondate;
				}

				info.CurrentClass = CurrentClass;

				info.CompanyName = Company.CompanyName;
				info.MiddleName = MiddleName;
				
					info.ParentID = ParentName;
				try
				{
					db.Entry(CurrenAccademicYear).State = EntityState.Modified;
					db.Users.Add(info);

					db.SaveChanges();
				}
				catch (Exception ex) { }
				
				SuccessLbl.Text = "Successfull";
			}
		}
	}
}