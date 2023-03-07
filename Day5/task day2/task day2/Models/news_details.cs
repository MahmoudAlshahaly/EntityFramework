using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day2.Models
{
   public class news_details
    {
        public int id { get; set; }
        public int name { get; set; }
        public virtual news news { get; set; }

    }
}
