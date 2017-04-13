using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF6_CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. The migrations are run even we do not run the context. Seems that this approach fits better to installers.
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //2. The migrations are run the first time the context is used within the application process.
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DecompressDatabaseMigration decompress = new DecompressDatabaseMigration();
            decompress.DecompressModel(
                "201704120821095_AddBlogUrl",
                @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EF6_CodeFirst.BloggingContext;Integrated Security=True");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DecompressDatabaseMigration decompress = new DecompressDatabaseMigration();
            decompress.CompressModel(
                "201704120821095_AddBlogUrl",
                @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EF6_CodeFirst.BloggingContext;Integrated Security=True",
                "AddBlogUrl.xml");
        }
    }
}
