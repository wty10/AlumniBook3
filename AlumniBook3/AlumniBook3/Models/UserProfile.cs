using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniBook3.Models
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int GraduatedYear { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public int Phone { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}