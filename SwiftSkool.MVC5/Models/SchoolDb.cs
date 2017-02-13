using SwiftSkool.MVC5.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SwiftSkool.MVC5.Models;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Models
{
    public class SchoolDb : IdentityDbContext<ApplicationUser, CustomRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public SchoolDb()
            : base("DefaultConnection")
        {
        }

        public static SchoolDb Create()
        {
            return new SchoolDb();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasKey(a => a.Id);
            builder.Entity<Attendance>().HasKey(a => a.Id);
            builder.Entity<Allergy>().HasKey(a => a.Id);

            builder.Entity<BehaviourActivity>().HasKey(b => b.Id);

            builder.Entity<Class>().HasKey(c => c.Id);
            builder.Entity<Club>().HasKey(c => c.Id);

            builder.Entity<Disability>().HasKey(d => d.Id);

            builder.Entity<EntranceExam>().HasKey(e => e.Id);
            builder.Entity<EntranceExamCandidate>().HasKey(e => e.Id);
            builder.Entity<EntranceExamRegistration>().HasKey(e => e.Id);
            builder.Entity<EntranceExamSubject>().HasKey(e => e.Id);

            builder.Entity<Guardian>().HasKey(g => g.Id);
            builder.Entity<Hostel>().HasKey(h => h.Id);
            builder.Entity<Illness>().HasKey(i => i.Id);
            builder.Entity<KeyToRating>().HasKey(i => i.Id);
            builder.Entity<LessonPlan>().HasKey(l => l.Id);
            builder.Entity<MedicalHistory>().HasKey(m => m.Id);

            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<PaymentType>().HasKey(p => p.Id);

            builder.Entity<Rating>().HasKey(r => r.Id);
            builder.Entity<Result>().HasKey(r => r.Id);

            builder.Entity<School>().HasKey(s => s.Id);
            builder.Entity<SchoolSession>().HasKey(s => s.Id);
            builder.Entity<ScoreGrade>().HasKey(s => s.Id);
            builder.Entity<Student>().HasKey(s => s.Id);
            builder.Entity<Subject>().HasKey(s => s.Id);

            builder.Entity<ContinuousAssessment>().HasKey(t => t.Id);

            //builder.Entity<StudentsSubjects>()
            //       .HasKey(ss => new { ss.StudentId, ss.SubjectId });
            builder.Entity<State>()
                   .HasKey(s => s.Id);
            builder.Entity<LocalGovernment>()
                   .HasKey(l => l.Id);

            builder.Entity<Allergy>()
                   .HasRequired(a => a.MedicalHistory)
                   .WithMany(m => m.Allergies)
                   .HasForeignKey(a => a.MedicalHistoryId)
                   .WillCascadeOnDelete(false);
            builder.Entity<Attendance>()
                   .HasMany(a => a.Students)
                   .WithOptional(s => s.Attendance)
                   .HasForeignKey(s => s.AttendanceId)
                   .WillCascadeOnDelete(false);
            builder.Entity<Attendance>()
                   .HasRequired(a => a.FormTeacher)
                   .WithOptional().WillCascadeOnDelete(false);
            builder.Entity<BehaviourActivity>()
                   .HasRequired(b => b.KeyToRating)
                   .WithRequiredPrincipal(k => k.BehaviourActivity)
                   .WillCascadeOnDelete(false);
            //builder.Entity<Class>()
            //       .HasMany(c => c.Students)
            //       .WithRequired(s => s.Class)
            //       .HasForeignKey<Student>(s => s.ClassId).WillCascadeOnDelete(false);
            //builder.Entity<Club>()
            //       .WithOptional(s => s.Club)
            //       .HasForeignKey(s => s.ClubId)
            //       .WillCascadeOnDelete(false);
            builder.Entity<ContinuousAssessment>()
                   .HasRequired(x => x.Result)
                   .WithMany(r => (List<ContinuousAssessment>)r.ContinuousAssessments)
                   .WillCascadeOnDelete(false);
            builder.Entity<Disability>()
                   .HasRequired(d => d.MedicalHistory)
                   .WithMany(m => m.Disabilities)
                   .HasForeignKey(m => m.MedicalHistoryId)
                   .WillCascadeOnDelete(false);
            builder.Entity<EntranceExam>()
                   .HasMany(e => e.EntranceExamCandidates)
                   .WithRequired(e => e.EntranceExam)
                   .HasForeignKey(e => e.EntranceExamId)
                   .WillCascadeOnDelete();
            builder.Entity<EntranceExamCandidate>()
                   .HasMany(e => e.ExamSubjects)
                   .WithRequired(e => e.EntranceExamCandidate)
                   .HasForeignKey(e => e.EntranceExamCandidateId)
                   .WillCascadeOnDelete(false);
            builder.Entity<Guardian>()
                   .HasMany(g => g.Students)
                   .WithRequired(s => s.Guardian)
                   .HasForeignKey(s => s.GuardianId)
                   .WillCascadeOnDelete(false);
            //builder.Entity<Hostel>()
            //       .HasRequired(h => h.Patron)
            //       .WithOptional().WillCascadeOnDelete(false);
            builder.Entity<Illness>()
                   .HasRequired(i => i.MedicalHistory)
                   .WithMany(m => m.Illnesses)
                   .HasForeignKey(i => i.MedicalHistoryId)
                   .WillCascadeOnDelete(false);
            builder.Entity<LessonPlan>()
                   .HasRequired(l => l.Session)
                   .WithOptional()
                   .WillCascadeOnDelete(false);
            builder.Entity<LessonPlan>()
                   .HasRequired(l => l.Subject)
                   .WithOptional(s => s.LessonPlan)
                   .WillCascadeOnDelete(false);
            builder.Entity<LessonPlan>()
                   .HasRequired(l => l.Teacher)
                   .WithMany(t => t.LessonPlans)
                   .HasForeignKey(l => l.TeacherId)
                   .WillCascadeOnDelete(false);
            builder.Entity<MedicalHistory>()
                   .HasRequired(m => m.Student)
                   .WithOptional(s => s.MedicalHistory)
                   .WillCascadeOnDelete(false);
            builder.Entity<Payment>()
                   .HasMany(p => p.PaymentTypes)
                   .WithOptional().WillCascadeOnDelete(false);
            builder.Entity<Rating>()
                   .HasRequired(r => r.BehaviourActivity)
                   .WithRequiredPrincipal(b => b.Rating)
                   .WillCascadeOnDelete(false);
            builder.Entity<Result>()
                   .HasRequired(r => r.Student)
                   .WithMany(s => (List<Result>)s.Results)
                   .HasForeignKey(r => r.StudentId)
                   .WillCascadeOnDelete(false);
            builder.Entity<Result>()
                   .HasRequired(r => r.Subject)
                   .WithOptional().WillCascadeOnDelete(false);
            
            builder.Entity<School>()
                   .HasMany(s => s.Staff)
                   .WithOptional(s => s.School)
                   .HasForeignKey(s => s.SchoolId).WillCascadeOnDelete(false);
            builder.Entity<School>()
                   .HasMany(s => s.Students)
                   .WithOptional().WillCascadeOnDelete(false);
            builder.Entity<School>()
                   .HasMany(s => s.Staff)
                   .WithOptional().WillCascadeOnDelete(false);
            builder.Entity<SchoolSession>()
                   .HasOptional(s => s.School)
                   .WithMany(s => s.Sessions)
                   .HasForeignKey(s => s.SchoolId)
                   .WillCascadeOnDelete(false);
            builder.Entity<ScoreGrade>()
                   .HasRequired(s => s.Grade)
                   .WithOptional()
                   .WillCascadeOnDelete(false);
            builder.Entity<ScoreGrade>()
                   .HasRequired(s => s.Subject)
                   .WithOptional(s => s.ScoreGrade)
                   .WillCascadeOnDelete(false);
            builder.Entity<State>()
                   .HasMany(s => s.LocalGovt)
                   .WithRequired(s => s.State)
                   .HasForeignKey(l => l.StateId)
                   .WillCascadeOnDelete(false);
        }

        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<Illness> Illnesses { get; set; }

        public DbSet<Disability> Disabilities { get; set; }

        public DbSet<Allergy> Allergies { get; set; }

        public DbSet<EntranceExam> EntranceExams { get; set; }

        public DbSet<EntranceExamCandidate> EntranceExamCanditates { get; set; }

        public DbSet<EntranceExamSubject> EntranceExamSubjects { get; set; }

        public DbSet<EntranceExamRegistration> EntranceExamRegistrations { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<SchoolSession> Sessions { get; set; }

        public DbSet<ContinuousAssessment> ContinuousAssessment { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<LocalGovernment> LGAs { get; set; }

        public DbSet<ScoreGrade> ScoreGrades { get; set; }

        public DbSet<LessonPlan> LessonPlans { get; set; }

        public DbSet<Hostel> Hostels { get; set; }

        public DbSet<Guardian> Guardians { get; set; }

        public DbSet<BehaviourActivity> BehaviourActivities { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Club> Clubs { get; set; }
    }
}
