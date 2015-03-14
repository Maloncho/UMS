using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [StringLength(20, MinimumLength = 1)]
        [Remote("IsCodeExist", "Course", ErrorMessage = "This code already Exits")]
        [Display(Name = "Course Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(70, MinimumLength = 1)]
        [Remote("IsNameExist", "Course", ErrorMessage = "This name already Exits")]
        public string Name { get; set; }



        [Required]
        public double Credit { get; set; }
        public string Description { get; set; }




        [Required(ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }




        [Required(ErrorMessage = "Please select semester")]
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }



        public virtual List<CourseAssign> CourseAssigns { get; set; }
        public virtual List<EnrollCourse> EnrollCourses { get; set; }
     
    }
}