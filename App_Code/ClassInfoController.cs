using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SchoolManagementReport.App_Code
{
	public class ClassInfoController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = ConfigurationManager.ConnectionStrings["Connection"].ToString();
		public IEnumerable<string> Disquery { get; private set; }

		[HttpGet] 
		public IEnumerable<string> GetAllClassLevel()
		{

			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.ClassLevel.Select(x => x.CLassLevel).ToList().Distinct();
			return Disquery;
		}
		[HttpGet]
		public IEnumerable<string> GetAllClassCategory(string Level)
		{

			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.ClassCategory.Where(x=>x.ClassLevel==Level).Select(x => x.ClassCategory).ToList().Distinct();
			return Disquery;
		}

		// POST api/<controller>
		public IEnumerable<Models.ClassInformation> GetAllClasses()
		{
			IEnumerable<Models.ClassInformation> Disquery = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.ClassInfo.ToList().Distinct();
			return Disquery;
		}

		// PUT api/<controller>/5
		public IEnumerable<UserInformation> GetAllTeachers()
		{
			IEnumerable<UserInformation> Disquery = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.Users.Where(c=>c.IsActive==true && c.Designation=="Teacher").ToList().Distinct();
			return Disquery;
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}