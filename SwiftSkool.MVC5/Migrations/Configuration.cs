using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;

namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolDb ctx)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!ctx.Sessions.Any())
            {
                var session = new SchoolSession("2016/2017");
                ctx.Sessions.AddOrUpdate(session);
                ctx.SaveChanges();
            }

            if (!ctx.SchoolTerms.Any())
            {
                var first = new SchoolTerm("First Term", new DateTime(2016, 9, 22), new DateTime(2016, 12, 18));
                first.SchoolSessionId = 1;
                var second = new SchoolTerm("Second Term", new DateTime(2017, 01, 09), new DateTime(2017, 03, 19));
                second.SchoolSessionId = 1;
                var third = new SchoolTerm("Third Term", new DateTime(2017, 04, 09), new DateTime(2017, 07, 1));
                third.SchoolSessionId = 1;

                ctx.SchoolTerms.AddOrUpdate(first);
                ctx.SchoolTerms.AddOrUpdate(second);
                ctx.SchoolTerms.AddOrUpdate(third);
                ctx.SaveChanges();
            }
        }
    }
}
