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
	public partial class ClassInformation : System.Web.UI.Page
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
			if(Request.Form["ClassID"]!=null)
			{ 
			RowID = int.Parse(Request.Form["ClassID"]);
			}
			var classRecord =db.ClassInfo.FirstOrDefault(x=>x.ClassID == RowID);
			if (classRecord == null){
			Models.ClassInformation record = new Models.ClassInformation();
				record.Teacher = Request.Form["ClassTeacher"];
				record.Name = Request.Form["ClassName"];
				record.ClassLevel= Request.Form["ClassLevel"];
				record.Population = int.Parse(Request.Form["Population"]);
				db.ClassInfo.Add(record);
			try
				{
					var ClassTeacher = db.Users.FirstOrDefault(x => x.UserID == record.Teacher);

					if (ClassTeacher != null) { ClassTeacher.IsClassTeacher = true; }
					db.Entry(ClassTeacher).State = EntityState.Modified;

					db.SaveChanges();
				}catch (Exception ex){ }
			
			}else{
				classRecord.Teacher = Request.Form["ClassTeacher"];
				classRecord.Name = Request.Form["ClassName"];
				classRecord.ClassLevel = Request.Form["ClassLevel"];
				classRecord.Population = int.Parse(Request.Form["Population"]);
				try{
					db.Entry(classRecord).State = EntityState.Modified;
					db.SaveChanges();
				}catch(Exception ex){ }
				
			}
		}
	}
}