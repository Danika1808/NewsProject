using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.Web.App
{
    public class UserProfile
    {
        public Guid Id { get; protected set; }

        [MaxLength(20, ErrorMessage = "Line length exceeded")]
        public string Name { get; protected set; }

        [MaxLength(20, ErrorMessage = "Line length exceeded")]
        public string LastName { get; protected set; }

        [Range(1, 110, ErrorMessage = "Incoffect Age")]
        public sbyte Age { get; protected set; }
        [Phone]
        public string Phone { get; protected set; }
        [MaxLength(20, ErrorMessage = "Max length 20")]
        public string City { get; protected set; }
        public string Address { get; protected set; }

        [ForeignKey("AspNetUsers")]
        public User User { get; protected set; }
    }
}
