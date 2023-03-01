using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Models
{
    public partial class Department
    {
        public Department()
        {
            Instructors = new HashSet<Instructor>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public string DeptLocation { get; set; }
        public int? DeptManager { get; set; }
        public DateTime? ManagerHiredate { get; set; }

        public virtual Instructor DeptManagerNavigation { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
