using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
    public partial class DashBoard : System.Web.UI.Page
    {
		DbConnectContext db = new DbConnectContext();
		public Boolean Admin { get; set; } = false;
    public Boolean Teacher { get; set; } = false;
    public Boolean Student { get; set; } = false;
    public Boolean Guardian { get; set; } = false;
    protected void Page_Load(object sender, EventArgs e)
        {
        if(Session["Designation"]!=null) {

        if (Session["Designation"].ToString()=="Teacher") { Teacher = true; }
        if (Session["Designation"].ToString() == "Admin") { Admin = true; }
        if (Session["Designation"].ToString() == "Student") { Student = true; }
        if (Session["Designation"].ToString() == "Parent") { Guardian = true; }
				

					string Target = Request.Form["Import"];
					if (Target == "ImportStudents")
					{
					UploadStudents();
					}else if(Target == "ImportTeacher")
				{
					UploadTeacher();
					}else if(Target == "ImportSubject") {
					UploadSubject();
					}else if(Target== "ImportResults") { UploadResult(); }

	
       
      }else{ Response.Redirect("./Default.aspx"); }
        }

		private void UploadResult()
		{
			
		}

		private void UploadSubject()
		{
			try
			{
				var UploadFile = ImportSubjects;
				if (UploadFile.PostedFile != null)
				{
					string TemplateUrl = "~/Admin/Templates/";
					string ExcelConnectionString = ConfigurationManager.ConnectionStrings["ExcelConnection"].ToString();
					try
					{
						string path = string.Concat(Server.MapPath(TemplateUrl + UploadFile.FileName));
						UploadFile.SaveAs(path);
						string excelCS = string.Format(ExcelConnectionString, path);
						using (OleDbConnection con = new OleDbConnection(excelCS))
						{
							con.Open();
							DataTable excelTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
							string TableName = excelTable.Rows[0]["TABLE_NAME"].ToString();
							if (!TableName.Contains("$"))
							{
								TableName = TableName + "$";
							}
							OleDbDataAdapter cmd = new OleDbDataAdapter("select Distinct  * from [" + TableName + "]", con);


							DataTable excelDataTable = new DataTable();
							cmd.Fill(excelDataTable);
							var Company = db.Company.FirstOrDefault();
							foreach (DataRow rows in excelDataTable.Rows)
							{
								SubjectInformation info = new SubjectInformation();

								//info.SubjectTeacher = rows["SubjectTeacher"].ToString();
								info.ClassLevel = rows["SubjectLevel"].ToString();
								info.SubjectName = rows["SubjectName"].ToString();
								info.ClassCategory = rows["ClassCategory"].ToString();

								db.Subject.Add(info);

								db.SaveChanges();
							}

						}


						//	showMessage("Your file uploaded successfully", "success");
						//	int branchid = int.Parse(BranchID.Value);
						//	int departmentid = int.Parse(DepartmentID.Value);
						//		int companyid = int.Parse(Session["CompanyID"].ToString());
						//		App.LogAudit(Application["UserName"].ToString(), "", "", "Uploaded Employee", companyid, branchid, departmentid);


					}
					catch (Exception ex)
					{
						//	errorLbl.Text = "Error- " + ex.Message;
						//	errorLbl.Style["color"] = "red";
						//			App.CaptureError(ex.Message, "UploadFiles -EmployeeInformation.aspx");
						//	showMessage(ex.Message, "error");
					}

				}
			}
			catch (Exception ex) { }
		}

		private void UploadTeacher()
		{
			try
			{
				var UploadFile = ImportTeachers;
				if (UploadFile.PostedFile != null)
				{
					string TemplateUrl = "~/Admin/Templates/";
					string ExcelConnectionString = ConfigurationManager.ConnectionStrings["ExcelConnection"].ToString();
					try
					{
						string path = string.Concat(Server.MapPath(TemplateUrl + UploadFile.FileName));
						UploadFile.SaveAs(path);
						string excelCS = string.Format(ExcelConnectionString, path);
						using (OleDbConnection con = new OleDbConnection(excelCS))
						{
							con.Open();
							DataTable excelTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
							string TableName = excelTable.Rows[0]["TABLE_NAME"].ToString();
							if (!TableName.Contains("$"))
							{
								TableName = TableName + "$";
							}
							OleDbDataAdapter cmd = new OleDbDataAdapter("select Distinct  * from [" + TableName + "]", con);


							DataTable excelDataTable = new DataTable();
							cmd.Fill(excelDataTable);
							var Company = db.Company.FirstOrDefault();
							foreach (DataRow rows in excelDataTable.Rows)
							{
								UserInformation info = new UserInformation();
							
									info.Designation = "Teacher";
									info.DOB = DateTime.Parse(rows["DOB"].ToString());
									info.Email = rows["Email"].ToString();
									info.FirstName = rows["FirstName"].ToString();
									info.Phone = rows["Phone"].ToString();
									info.LastName = rows["LastName"].ToString();
									if (rows["Active"] == null) { info.IsActive = false; }
									else
									{
										info.IsActive = Convert.ToBoolean(rows["Active"].ToString());
									}
									if(rows["IsClassTeacher"]==null) { info.IsClassTeacher = false; }else{
									info.IsClassTeacher = Convert.ToBoolean(rows["IsClassTeacher"].ToString());
								}

								if (rows["IsSubjectTeacher"] == null) { info.IsSubjectTeacher = false; }
								else
								{
									info.IsSubjectTeacher = Convert.ToBoolean(rows["IsSubjectTeacher"].ToString());
								}
						if(rows["UserID"]!=null){
									info.UserID = rows["UserID"].ToString();
								}else{
									info.UserID = rows["FirstName"].ToString();
								}
									
									info.Password = Guid.NewGuid().ToString();
								
									info.Gender = rows["Gender"].ToString();
									

									

									info.CompanyName = Company.CompanyName;
									info.MiddleName = rows["MiddleName"].ToString();
									

									db.Users.Add(info);

									db.SaveChanges();
								}

							}


							//	showMessage("Your file uploaded successfully", "success");
							//	int branchid = int.Parse(BranchID.Value);
							//	int departmentid = int.Parse(DepartmentID.Value);
							//		int companyid = int.Parse(Session["CompanyID"].ToString());
							//		App.LogAudit(Application["UserName"].ToString(), "", "", "Uploaded Employee", companyid, branchid, departmentid);

						
					}
					catch (Exception ex)
					{
						//	errorLbl.Text = "Error- " + ex.Message;
						//	errorLbl.Style["color"] = "red";
						//			App.CaptureError(ex.Message, "UploadFiles -EmployeeInformation.aspx");
						//	showMessage(ex.Message, "error");
					}

				}
			}
			catch (Exception ex) { }
		}

		private void UploadStudents()
		{
			try {
				var UploadFile = ImportStudents;
				if (UploadFile.PostedFile != null)
				{
					string TemplateUrl = "~/Admin/Templates/";
					string ExcelConnectionString = ConfigurationManager.ConnectionStrings["ExcelConnection"].ToString();
					try
					{
						string path = string.Concat(Server.MapPath(TemplateUrl + UploadFile.FileName));
						UploadFile.SaveAs(path);
						string excelCS = string.Format(ExcelConnectionString, path);
						using (OleDbConnection con = new OleDbConnection(excelCS))
						{
							con.Open();
							DataTable excelTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
							string TableName = excelTable.Rows[0]["TABLE_NAME"].ToString();
							if (!TableName.Contains("$"))
							{
								TableName = TableName + "$";
							}
							OleDbDataAdapter cmd = new OleDbDataAdapter("select Distinct  * from [" + TableName + "]", con);


							DataTable excelDataTable = new DataTable();
							cmd.Fill(excelDataTable);
							var Company = db.Company.FirstOrDefault();
							foreach (DataRow rows in excelDataTable.Rows)
							{
								UserInformation info = new UserInformation();
								
									info.Designation = "Student";
									info.DOB = DateTime.Parse(rows["DOB"].ToString());
									info.Email = rows["Email"].ToString();
									info.FirstName = rows["FirstName"].ToString();
									info.Phone = rows["Phone"].ToString();
									info.LastName = rows["LastName"].ToString();
									if (rows["Active"] == null) { info.IsActive = false; } else {
										info.IsActive = Convert.ToBoolean(rows["Active"].ToString());
									}
									info.ClassTeacher = rows["ClassTeacher"].ToString();

									info.SessionAdmitted = rows["SessionAdmitted"].ToString();
									info.UserID = rows["FirstName"].ToString();
									info.Password = Guid.NewGuid().ToString(); 
								info.AdmissionID = rows["AdmissionID"].ToString();
									info.Gender = rows["Gender"].ToString();
									if (rows["BloodGroup"] != null) {
										info.BloodGroup = rows["BloodGroup"].ToString();
									}

									if (rows["DateAdmitted"] == null)
									{
										info.DateAdmitted = DateTime.Parse("1900-01-01");
									} else {
										info.DateAdmitted = DateTime.Parse(rows["DateAdmitted"].ToString());
									}

									info.CurrentClass = rows["CurrentClass"].ToString();

									info.CompanyName = Company.CompanyName;
									info.MiddleName = rows["MiddleName"].ToString();
									if (rows["ParentID"] != null) {
										info.ParentID = rows["ParentID"].ToString();
									}else { info.ParentID = Guid.NewGuid().ToString(); }
							
								db.Users.Add(info);

									db.SaveChanges();
								}

							}


							//	showMessage("Your file uploaded successfully", "success");
							//	int branchid = int.Parse(BranchID.Value);
							//	int departmentid = int.Parse(DepartmentID.Value);
							//		int companyid = int.Parse(Session["CompanyID"].ToString());
							//		App.LogAudit(Application["UserName"].ToString(), "", "", "Uploaded Employee", companyid, branchid, departmentid);

						
					}
					catch (Exception ex)
					{
						//	errorLbl.Text = "Error- " + ex.Message;
						//	errorLbl.Style["color"] = "red";
						//			App.CaptureError(ex.Message, "UploadFiles -EmployeeInformation.aspx");
						//	showMessage(ex.Message, "error");
					}
				
			}
			}
			catch (Exception ex) { }
		}

	}
}