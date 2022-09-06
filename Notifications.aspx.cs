using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
	public partial class Notifications : System.Web.UI.Page
	{
		DbConnectContext db = new DbConnectContext();
	public	string postedBy { get; set; }	= string.Empty;
		public string Narration { get; set; } = string.Empty;
		public string startDate { get; set; } = DateTime.Now.ToShortDateString();
		public string endDate { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
		if(Session["UserName"]!=null) {
				string UserName = Session["UserName"].ToString();
				string Password = Session["Password"].ToString();
				string ComapanyName = Session["CompanyName"].ToString();
				var validUser = db.Users.Where(x => x.Password == Password && x.UserID == UserName && x.IsActive == true && x.CompanyName == ComapanyName).FirstOrDefault();
				if (validUser != null) {
					postedBy = validUser.LastName+" "+ validUser.FirstName;

				}
				string Target = Request.Form["Save"];
				if (Target == "SaveRecord")
				{
					SaveRecord();
				}
			}
			else{
				Response.Redirect("Default.aspx");
			}
		}

		

		private void SaveRecord()
		{
			int RowID = 0;
			if (!string.IsNullOrEmpty(Request.Form["RowID"])) {
				RowID = int.Parse(Request.Form["RowID"]);
			}
	

			var NoticeRecord =db.Notification.FirstOrDefault(x =>x.ID == RowID);
			if (NoticeRecord == null) {
				Models.Notifications notifications = new Models.Notifications();
				notifications.Narrative = Request.Form["Narration"];
				notifications.StartDate = DateTime.Parse(Request.Form["startDate"]);
				notifications.EndDate = DateTime.Parse(Request.Form["EndDate"]);
				notifications.Signatory = Request.Form["signatory"];



				
				db.Notification.Add(notifications);
				db.SaveChanges();
			}else{
				NoticeRecord.Narrative = Request.Form["Narration"];
				NoticeRecord.StartDate = DateTime.Parse(Request.Form["startDate"]);
				NoticeRecord.EndDate = DateTime.Parse(Request.Form["EndDate"]);
				NoticeRecord.Signatory = Request.Form["signatory"];
				db.Entry(NoticeRecord).State=System.Data.Entity.EntityState.Modified;
				db.SaveChanges();
			}
		}
	}
}