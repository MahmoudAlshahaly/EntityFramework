using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day2.Models
{
   public class news
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual author author { get; set; }
        public virtual ICollection<news_details> news_details { get; set; }
    }
}
