using SchoolManagementReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SchoolManagementReport.App_Code
{
	public class AccademicYearController : ApiController
	{
		DbConnectContext db = new DbConnectContext();
		string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ToString();
		public IEnumerable<string> query { get; private set; }
		public IEnumerable<SessionsInformation> GetCurrentAccademicYear()
		{
			IEnumerable<SessionsInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			query = db.Session
			.Where(x => x.CurrentSession ==true).ToList().Distinct();
			return query;
		}
		
			public IEnumerable<SessionsInformation> GetAllAccademicYear()
		{
			IEnumerable<SessionsInformation> query = null;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return query;
			}
			try{
			
				query = db.Session.ToArray().Distinct();
			}
			catch(Exception ex){ }
		
			return query;
		}

		public bool UpdateAccademicYear([FromBody] SessionsInformation value)
		{
			bool result = false;
			if (HttpContext.Current.Session["UserName"] == null)
			{
				return false;
			}
			bool Result = ResetAccademicYear();
		
				var query = db.Session.FirstOrDefault(x => x.AcademicYear == value.AcademicYear);
				try
				{

					if (query != null)
					{


					//	query.AcademicYear = value.AcademicYear;
						query.CurrentSession = value.CurrentSession;
						db.Entry(query).State = EntityState.Modified;
						db.SaveChanges();
						result = true;
					}
					else
					{
						SessionsInformation Newquery = new SessionsInformation();
						Newquery.CurrentSession = value.CurrentSession;
						Newquery.AcademicYear = value.AcademicYear;

						db.Session.Add(Newquery);
						db.SaveChanges();
					}
				}
				catch (Exception ex) { return result; }
			
			return result;
		}

		private bool ResetAccademicYear()
		{
			
			var query = db.Session.FirstOrDefault(z=>z.CurrentSession ==true);
			if(query!=null){ 
			query.CurrentSession = false;
				db.Entry(query).State = EntityState.Modified;
				db.SaveChanges();
			}
			
			return true;
		}
	}
}