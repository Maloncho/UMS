using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<UniversityDBContext>
    {
        protected override void Seed(UniversityDBContext context)
        {
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Account', RESEED, 1000000)");
            context.Semesters.Add(new Semester() { SemesterName = "First Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Second Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Thrid Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Fourth Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Fifth Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Sixth Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Seventh Semester" });
            context.Semesters.Add(new Semester() { SemesterName = "Eighth Semester" });
            context.SaveChanges();
            context.Designations.Add(new Designation() { DesignationName = "Lecturer" });
            context.Designations.Add(new Designation() { DesignationName = "Assistant Professor" });
            context.Designations.Add(new Designation() { DesignationName = "Associate Professor" });
            context.Designations.Add(new Designation() { DesignationName = "Professor" });
            context.Designations.Add(new Designation() { DesignationName = "DEAN" });
            context.Designations.Add(new Designation() { DesignationName = "Guest Teacher" });
            context.Designations.Add(new Designation() { DesignationName = "Senior Lecturer" });
            context.SaveChanges();




            context.Departments.Add(new Department() { Code = "CSE", Name = "Computer Science" });
            context.Departments.Add(new Department() { Code = "EEE", Name = "Electrical and Elec." });
            context.Departments.Add(new Department() { Code = "PHY", Name = "Physics" });
            context.Departments.Add(new Department() { Code = "MATH", Name = "Math" });
            context.Departments.Add(new Department() { Code = "CE", Name = "Civil" });
            context.SaveChanges();
            context.Courses.Add(new Course() { Code = "101", Name = "C", Credit = 3, Description = "ComputerF.", DepartmentId = 1, SemesterId = 1 });
            context.Courses.Add(new Course() { Code = "102", Name = "C++", Credit = 2, Description = "Computer Programming", DepartmentId = 2, SemesterId = 2 });
            context.Courses.Add(new Course() { Code = "103", Name = "Electronics....", Credit = 4, Description = "Electrical", DepartmentId = 1, SemesterId = 1 });
            context.Courses.Add(new Course() { Code = "104", Name = "Electronics1....", Credit = 3, Description = "Electrical1...", DepartmentId = 2, SemesterId = 2 });
            context.SaveChanges();

            //context.Teachers.Add(new Teacher() { Name = "Sukarno Barua",Email = "sukarno@gmail.com",Address = "BUET", ContactNo = "12345", Credit = 6.0, DesignationId = 1 ,DepartmentId = 1});
            //context.Teachers.Add(new Teacher() { Name = "Ashis Kumar", Email = "ashis@gmail.com", Address = "DU", ContactNo = "1111", Credit = 4.0, DesignationId = 1, DepartmentId = 1 });
            //context.SaveChanges();
            //context.Students.Add(new Student() { StudentId = 101, Name = "A", Email = "a@gmail.com", Date = DateTime.Now.Date, Address = "A", DepartmentId = 1, ContactNo = "123" });
            //context.SaveChanges();
        }
 
    }
}