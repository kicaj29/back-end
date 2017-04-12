using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_CodeFirst_MergeConflicts
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}
