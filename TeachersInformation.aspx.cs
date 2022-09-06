using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
	public partial class TeachersInformation : System.Web.UI.Page
	{
		DbConnectContext db = new DbConnectContext();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["UserName"] != null)
			{
				string Target = Request.Form["Save"];
				if (Target == "SaveRecord")
				{
					SaveRecord();
				}
			}
		}

		private void SaveRecord()
		{
		int RowID = 0;
			bool active = false;
			bool SubjectTeacher = false;
			bool ClassTeacher = false;
			if (!string.IsNullOrEmpty(Request.Form["RowID"])){
				RowID = int.Parse(Request.Form["RowID"]);
		}
		string UserID = Request.Form["UserID"];
			string isactive = Request.Form["IsActive"];
			string ISubjectTeacher = Request.Form["IsSubjectTeacher"];
			string IsClassTeacher = Request.Form["IsClassTeacher"];
			if (IsClassTeacher == "on") { ClassTeacher =true; }
			if (isactive == "on") { active =true; }
			if (ISubjectTeacher == "on") { SubjectTeacher =true; }
			var Company = db.Company.FirstOrDefault();

			var TeacherRecord = db.Users.FirstOrDefault(x => x.RowID == RowID && x.UserID == UserID);
			if (TeacherRecord == null){
	UserInformation NewTeacherRecord = new UserInformation();

				NewTeacherRecord.UserID = Request.Form["vUserID"];
				NewTeacherRecord.MiddleName = Request.Form["MiddleName"];
				NewTeacherRecord.LastName = Request.Form["LastName"];
				NewTeacherRecord.Password =Guid.NewGuid().ToString();
				NewTeacherRecord.Designation = "Teacher";
				NewTeacherRecord.Phone = Request.Form["Phone"];
				NewTeacherRecord.Email = Request.Form["Email"];
				NewTeacherRecord.ResidentialAddress = Request.Form["Address"];
				NewTeacherRecord.IsActive = active;
				NewTeacherRecord.IsSubjectTeacher = SubjectTeacher;
				NewTeacherRecord.IsClassTeacher = ClassTeacher;
				NewTeacherRecord.CompanyName = Company.CompanyName;
				db.Users.Add(NewTeacherRecord);
				db.SaveChanges();
			}else{
				//TeacherRecord.UserID = Request.Form["FirstName"];
				TeacherRecord.MiddleName = Request.Form["MiddleName"];
				TeacherRecord.LastName = Request.Form["LastName"];
			//	TeacherRecord.Password = Guid.NewGuid().ToString();
				//TeacherRecord.Designation = "Teacher";
				TeacherRecord.Phone = Request.Form["Phone"];
				TeacherRecord.Email = Request.Form["Email"];
				TeacherRecord.ResidentialAddress = Request.Form["Address"];
				TeacherRecord.IsActive = active;
				TeacherRecord.IsSubjectTeacher = SubjectTeacher;
				TeacherRecord.IsClassTeacher =ClassTeacher;
				db.Entry(TeacherRecord).State =System.Data.Entity.EntityState.Modified;
				db.SaveChanges();
			}
		}
	}
}