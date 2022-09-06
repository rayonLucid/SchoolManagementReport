using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
	public partial class Subjects : System.Web.UI.Page
	{
		DbConnectContext db = new DbConnectContext();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Designation"] != null)
			{

				string Target = Request.Form["Save"];
				if (Target == "SaveRecord")
				{
					SaveSubject();
				}
			}
			else { Response.Redirect("./Default.aspx"); }

		}

		private void SaveSubject()
		{
		//	string SubjectTeacher = Request.Form["SubjectTeacher"];
			string SubjectLevel = Request.Form["ClassLevel"];
			string SubjectName = Request.Form["SubjectName"];
			string ClassCategory = Request.Form["ClassCategory"];
			int RowID = int.Parse(Request.Form["RowID"]);
			try{

				var Query = db.Subject.FirstOrDefault(x => x.ID == RowID);
				if (Query.ID == 0 || Query == null)
				{
					Query.ClassLevel = SubjectLevel;
					Query.SubjectName = SubjectName;
				//	Query.SubjectTeacher = SubjectTeacher;
					Query.ClassCategory = ClassCategory;
					db.Subject.Add(Query);
				}
				else
				{
					Query.ClassLevel = SubjectLevel;
					Query.SubjectName = SubjectName;
					//Query.SubjectTeacher = SubjectTeacher;
					Query.ClassCategory = ClassCategory;
					db.Entry(Query).State = EntityState.Modified;
				}
				db.SaveChanges();
			}
			catch(Exception ex){ }
			
		}
	}
}