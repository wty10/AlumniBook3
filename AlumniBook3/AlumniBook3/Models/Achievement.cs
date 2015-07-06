using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniBook3.Models
{
    public class Achievement
    {

        public int AchievementID { get; set; }
        
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}