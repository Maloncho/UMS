using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssign
    {
        public int CourseAssignId { set; get; }



        public int DepartmentId { set; get; }
        public virtual Department Department { set; get; }


        public int TeacherId { set; get; }
        public virtual Teacher Teacher { set; get; }


        public double AssignTaken { set; get; }
        public double RemainingTaken { set; get; }


        public int CourseId { set; get; }
        public virtual Course Course { set; get; }
    }
}