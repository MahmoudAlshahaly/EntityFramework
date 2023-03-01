using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Models
{
    public partial class Course
    {
        public int CrsId { get; set; }
        public string CrsName { get; set; }
        public int? CrsDuration { get; set; }
        public int? TopId { get; set; }
    }
}
