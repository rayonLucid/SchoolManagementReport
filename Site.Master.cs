using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementReport
{
    public partial class SiteMaster : MasterPage
    {
    public Boolean Admin { get; set; } = false;
    public Boolean Teacher { get; set; } = false;
    public Boolean Student { get; set; } = false;
    public Boolean Guardian { get; set; } = false;
    protected void Page_Load(object sender, EventArgs e)
        {
      if (Session["Designation"] != null)
      {

        if (Session["Designation"].ToString() == "Teacher") { Teacher = true; }
        if (Session["Designation"].ToString() == "Admin") { Admin = true; }
        if (Session["Designation"].ToString() == "Student") { Student = true; }
        if (Session["Designation"].ToString() == "Parent") { Guardian = true; }
      }else{
        Response.Redirect("./Default.aspx");
			}
    }
    }
}