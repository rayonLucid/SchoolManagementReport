
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolManagementReport.Models
{

public class DbConnectContext:DbContext
{
        public DbConnectContext() : base("name=connection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<DbConnectContext>(null);
            base.OnModelCreating(modelBuilder);
    }

        public DbSet<Notifications> Notification { get; set; }
        public DbSet<GuardianInformation> Guardian { get; set; }
        public DbSet<SessionsInformation> Session { get; set; }
        public DbSet<UserInformation> Users{ get; set; }
        public DbSet<SubjectInformation> Subject { get; set; }
    public DbSet<SubjectTeacherInformation> SubjectTeacher { get; set; }
    public DbSet<TermsInformation> Term {get;set;}
    public DbSet<CompanyInformation> Company { get; set; }
    public DbSet <SubjectLevelInformation> SubjectLevel { get; set; }
    public DbSet<ClassLevelInformation> ClassLevel { get; set; }
    public DbSet<ClassInformation> ClassInfo { get; set; }
    public DbSet<ClassCategoryInformation> ClassCategory { get; set; }
  }
}