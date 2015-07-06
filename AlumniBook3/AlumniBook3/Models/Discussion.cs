using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniBook3.Models
{
    public class Discussion
    {
        public int DiscussionID { get; set; }
        public int CategoryID { get; set; }
        //public Category Category { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int ReplyID { get; set; }
        public UserProfile User { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Discussion> Replies { get; set; }
    }
}