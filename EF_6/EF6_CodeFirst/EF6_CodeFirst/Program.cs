using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //Two ways to execute migrations from C# level:

            //1. The migrations are run the first time the context is used within the application process.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BloggingContext, Migrations.Configuration>());

            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Name = "Another Blog " });
                db.SaveChanges();

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
            }


            //2. The migrations are run even we do not run the context. Seems that this approach fits better to installers.
            //var configuration = new Migrations.Configuration();
            //var migrator = new DbMigrator(configuration);
            //migrator.Update();

        }
    }
}
