using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Web.App
{
    public class Comment
    {
        public Guid Id { get; protected set; }

        [MaxLength(20, ErrorMessage = "Line length exceeded")]
        public string Content { get; protected set; }

        public DataType date_of_publication { get; protected set; }

         [ForeignKey("AspNetUsers")]
        public User User { get; protected set; }


    }
}
