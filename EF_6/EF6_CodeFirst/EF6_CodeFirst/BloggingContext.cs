using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
using System.Diagnostics;

namespace EF6_CodeFirst
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base()
        { }

        public DbSet<Blog> Blogs { get; set; }
    }
}
