using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }


        public int RegNo { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact No is required.")]
        public string ContactNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<EnrollCourse> EnrollCourses { get; set; }
      
    }
}