using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day2.Models
{
  public  class author
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<news> news { get; set; }

    }
}
