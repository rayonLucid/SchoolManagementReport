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
	public class SubjectsController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = ConfigurationManager.ConnectionStrings["Connection"].ToString();

		public IEnumerable<string> Disquery { get; private set; }

		[HttpGet]
		public IEnumerable<SubjectInformation> GetAllSubjects()
		{
			IEnumerable<SubjectInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Subject.ToArray().Distinct();
			return query;
		}

	[HttpGet]
		public IEnumerable<string> GetAllSubjectLevel()
		{
			
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.SubjectLevel.Select(x=>x.ClassLevel).ToList().Distinct();
			return Disquery;
		}

		// POST api/<controller>
		public IEnumerable<UserInformation> GetAllSubjectTeacher()
		{
			IEnumerable<UserInformation> Disquery = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return Disquery;
			}
			Disquery = db.Users
			.Where(s =>s.IsSubjectTeacher ==true)
			.ToList().Distinct();
			return Disquery;
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