using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Web.App
{
    public class User : IdentityUser
    {
        public UserProfile Profile { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
