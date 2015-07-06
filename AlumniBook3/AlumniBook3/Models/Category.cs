using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniBook3.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}