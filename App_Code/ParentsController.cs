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
	public class ParentsController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ToString();
		public IEnumerable<string> query { get; private set; }
		public IEnumerable<UserInformation> GetAllParents()
		{
			IEnumerable<UserInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Users
			.Where(x => x.Designation =="Parent" && x.IsActive==true).ToArray().Distinct();
			return query;
		}
		
			public IEnumerable<UserInformation> GetParentChildren(string ParentID)
		{
			IEnumerable<UserInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			try{

				query = db.Users
				.Where(x => x.ParentID == ParentID && x.Designation == "Student" && x.IsActive == true).ToArray().Distinct();
			}
			catch(Exception ex){ }
		
			return query;
		}
		public IEnumerable<UserInformation> GetAllChildren(string ParentID)
		{
			IEnumerable<UserInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Users
			.Where(x => x.Designation == "Student" && x.ParentID == ParentID).ToList().Distinct();
			return query;
		}
		//// GET api/<controller>/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//[HttpGet]
		//public IEnumerable<string> GetClassCategory(string Level)
		//{
		//	if (HttpContext.Current.Session["UserName"] == null)
		//	{
		//		return query;
		//	}
		//	query = db.ClassCategory
		//	.Where(x => x.ClassLevel == Level).Select(x => x.ClassCategory).Distinct();
		//	return query;
		//}

		//// PUT api/<controller>/5
		//public bool UpdateTeacherSubject([FromBody] SubjectInformation value)
		//{
		//bool result = false;
		//	if (HttpContext.Current.Session["UserName"] == null)
		//	{
		//		return false;
		//	}
		//	var query = db.SubjectTeacher.FirstOrDefault(x => x.ID == value.ID);
		//	try{

		//		if (query != null)
		//		{

		//			query.SubjectName = value.SubjectName;
		//			query.ClassLevel = value.ClassLevel;
		//			query.ClassCategory = value.ClassCategory;
		//			db.Entry(query).State = System.Data.Entity.EntityState.Modified;
		//			db.SaveChanges();
		//			result = true;
		//		}
		//	}catch(Exception ex){ return result; }

		//	return result;
		//}

		//// DELETE api/<controller>/5
		//public IEnumerable<SubjectTeacherInformation> GetAllSubjectTeachers()
		//{
		//	IEnumerable<SubjectTeacherInformation> query = null;
		//	if (HttpContext.Current.Session["UserName"] == null)
		//	{
		//		return query;
		//	}
		//	query = db.SubjectTeacher
		//	.ToArray().Distinct();
		//	return query;
		//}
	}
}