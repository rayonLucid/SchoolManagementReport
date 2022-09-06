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
	public class StudentClassController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = ConfigurationManager.ConnectionStrings["Connection"].ToString();
		public IEnumerable<string> query { get; private set; }
		public IEnumerable<string> GetClassByLevel(string Level)
		{
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.ClassInfo
			.Where(x=>x.ClassLevel == Level).Select(x=>x.Name).ToList().Distinct();
			return query;
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}