using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
    public partial class _Default : Page
    {
        DbConnectContext db = new DbConnectContext();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request["LoginAction"];
            if (Action== "Login") {
                LoginUser();
            }
        }

        private void LoginUser()
        {
             UserName = Request.Form["uname"];
            string Password = Request.Form["psw"];
      var Company = db.Company.FirstOrDefault();
      if (Company == null) { return; }else if(Company.IsActive ==false) { return; }
            var validUser =  db.Users.Where(x => x.Password == Password && x.UserID == UserName && x.IsActive==true && x.CompanyName == Company.CompanyName).FirstOrDefault();
            if (validUser == null)
            {
                return ;
            }
            else
            {
        Session["Password"] = validUser.Password;
        Session["CompanyName"] = Company.CompanyName;
        Session["Designation"] = validUser.Designation;
        Session["UserName"] = validUser.UserID;
                Response.Redirect("~/Dashboard.aspx");
            }
        }
    }
}