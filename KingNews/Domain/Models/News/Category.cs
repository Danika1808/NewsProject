﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.News
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Entities { get; set; }

        public Category()
        {
        }
    }
}
