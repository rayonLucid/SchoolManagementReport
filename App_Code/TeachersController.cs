using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SchoolManagementReport.App_Code
{
	public class TeachersController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ToString();
		public IEnumerable<string> query { get; private set; }
		public IEnumerable<UserInformation> GetAllTeachers()
		{
			IEnumerable<UserInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Users
			.Where(x => x.Designation =="Teacher").Distinct();
			return query;
		}
		
			public IEnumerable<SubjectTeacherInformation> GetAllTeacherSubject(string UserName)
		{
			IEnumerable<SubjectTeacherInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			try{
			
				query = db.SubjectTeacher
				.Where(x => x.SubjectTeacher == UserName).ToArray().Distinct();
			}
			catch(Exception ex){ }
		
			return query;
		}
		public IEnumerable<string> GetSubjectByLevel(string Level,string ClassCategory)
		{
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Subject
			.Where(x => x.ClassLevel == Level && x.ClassCategory== ClassCategory).Select(x => x.SubjectName).Distinct();
			return query;
		}
		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		[HttpGet]
		public IEnumerable<string> GetClassCategory(string Level)
		{
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.ClassCategory
			.Where(x => x.ClassLevel == Level).Select(x => x.ClassCategory).Distinct();
			return query;
		}

		// PUT api/<controller>/5
		public bool UpdateTeacherSubject([FromBody] SubjectTeacherInformation value)
		{
		bool result = false;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return false;
			}
			var query = db.SubjectTeacher.FirstOrDefault(x => x.ID == value.ID);
			try{

				if (query != null)
				{

					query.SubjectName = value.SubjectName;
					query.ClassLevel = value.ClassLevel;
					query.ClassCategory = value.ClassCategory;
					db.Entry(query).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
					result = true;
				}else{
				SubjectTeacherInformation Newquery = new SubjectTeacherInformation();
					Newquery.SubjectName = value.SubjectName;
					Newquery.ClassLevel = value.ClassLevel;
					Newquery.ClassCategory = value.ClassCategory;
					Newquery.SubjectTeacher = value.SubjectTeacher;
					db.SubjectTeacher.Add(Newquery) ;
					db.SaveChanges();
				}
			}catch(Exception ex){ return result; }
		
			return result;
		}

		// DELETE api/<controller>/5
		public IEnumerable<SubjectTeacherInformation> GetAllSubjectTeachers()
		{
			IEnumerable<SubjectTeacherInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.SubjectTeacher
			.ToArray().Distinct();
			return query;
		}
	}
}