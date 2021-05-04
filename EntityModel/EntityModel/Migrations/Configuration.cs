namespace EntityModel.Migrations
{
    using EntityModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityModel.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityModel.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //var students = new List<Student>
            //{
            //new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            //new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            //new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            //};

            //students.ForEach(s => context.Students.Add(s));
            //context.SaveChanges();
            //var courses = new List<Course>
            //{
            //new Course{Title="Chemistry",Credits=3,},
            //new Course{Title="Microeconomics",Credits=3,},
            //new Course{Title="Macroeconomics",Credits=3,},
            //new Course{Title="Calculus",Credits=4,},
            //new Course{Title="Trigonometry",Credits=4,},
            //new Course{Title="Composition",Credits=3,},
            //new Course{Title="Literature",Credits=4,}
            //};
            //courses.ForEach(s => context.Courses.Add(s));
            //context.SaveChanges();
            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=4,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=1,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=3,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=5,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=6,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=7,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=2},
            //new Enrollment{StudentID=4,CourseID=3,},
            //new Enrollment{StudentID=4,CourseID=1,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=3,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=5},
            //new Enrollment{StudentID=7,CourseID=2,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();
        }
    }
}
