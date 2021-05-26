using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.News
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Patch { get; set; }

        public Photo()
        {
        }
    }
}
