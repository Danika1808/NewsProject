using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class User : IdentityUser
    {
        public List<Comment> Comments { get; set; }
        public Guid? ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
