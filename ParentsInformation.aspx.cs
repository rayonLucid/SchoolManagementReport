using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
	public partial class ParentsInformation : System.Web.UI.Page
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
			bool  active = false;
			if (!string.IsNullOrEmpty(Request.Form["RowID"]))
			{
				RowID = int.Parse(Request.Form["RowID"]);
			}
			string UserID = Request.Form["UserID"];
			string isactive = Request.Form["IsActive"];
			if(isactive =="on") { active = true; }
			var Company = db.Company.FirstOrDefault();
			var TeacherRecord = db.Users.FirstOrDefault(x => x.RowID == RowID && x.UserID == UserID);
			if (TeacherRecord == null)
			{
				UserInformation NewTeacherRecord = new UserInformation();
				NewTeacherRecord.UserID = Request.Form["FirstName"];
				NewTeacherRecord.FirstName = Request.Form["FirstName"];
				NewTeacherRecord.MiddleName = Request.Form["MiddleName"];
				NewTeacherRecord.LastName = Request.Form["LastName"];
				NewTeacherRecord.Password = Guid.NewGuid().ToString();
				NewTeacherRecord.Designation = "Parent";
				NewTeacherRecord.ParentID = Guid.NewGuid().ToString();
				NewTeacherRecord.Phone = Request.Form["Phone"];
				NewTeacherRecord.Email = Request.Form["Email"];
				NewTeacherRecord.CompanyName = Company.CompanyName;
				NewTeacherRecord.ResidentialAddress = Request.Form["ResidentialAddress"];
				NewTeacherRecord.IsActive = active;
			try
				{
					db.Users.Add(NewTeacherRecord);
					db.SaveChanges();
				}catch (Exception ex){ }
			
			}
			else
			{
			
				TeacherRecord.MiddleName = Request.Form["MiddleName"];
				TeacherRecord.LastName = Request.Form["LastName"];
				TeacherRecord.FirstName = Request.Form["FirstName"];
				TeacherRecord.Phone = Request.Form["Phone"];
				TeacherRecord.Email = Request.Form["Email"];
				TeacherRecord.ResidentialAddress = Request.Form["ResidentialAddress"];
				TeacherRecord.IsActive = active;
				try
				{
					db.Entry(TeacherRecord).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}catch(Exception ex){ }
			}
		}
	}
}