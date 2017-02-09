using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using SwiftSkool.MVC5.Entities;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole,
    CustomUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public async Task AsignTeacherToClass()
        //{
            
        //}

        public int StateId { get; set; }

        public State StateOfOrigin { get; set; }

        public Address Address { get; set; }

        public int LessonPlanId { get; set; }

        public List<LessonPlan> LessonPlans { get; set; }

        public List<Subject> Subjects { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public string Designation { get; set; }

        public string Passport { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Qualifications Qualifications { get; set; }

        public string Gender { get; set; }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(SchoolDb context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(SchoolDb context)
            : base(context)
        {
        }
    }
}