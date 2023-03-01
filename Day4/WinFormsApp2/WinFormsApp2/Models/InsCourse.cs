using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Models
{
    public partial class InsCourse
    {
        public int InsId { get; set; }
        public int CrsId { get; set; }
        public string Evaluation { get; set; }

        public virtual Instructor Ins { get; set; }
    }
}
