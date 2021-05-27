using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public sbyte Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        [ForeignKey("AspNetUsers")]
        public User User { get; set; }
    }
}
