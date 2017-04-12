using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog() { Name = "My Blog" };
                db.Blogs.Add(blog);
                db.SaveChanges();

                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }

        }
    }
}
