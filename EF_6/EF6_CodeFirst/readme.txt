https://msdn.microsoft.com/en-us/library/jj193542(v=vs.113).aspx

https://msdn.microsoft.com/en-us/library/dn579398(v=vs.113).aspx

https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx (SCENARIO 1 is mostly based on this article)

SCENARIO 1 Migrations without connecting to DB.

1.	Define DAO (model) in C#.

2.	In Package Manager Console execute: Enable-Migrations
This will create folder Migrations but without <timestamp>_InitialCreate.cs file.
NOTE: if the database would already exist then the <timestamp>_InitialCreate.cs would be created!!!

3.	In Package Manager Console execute: Add-Migration InitialCreate
This will create the file without connecting to any database.

4.	Execute InitialCreate from c# level (Program.cs)

				var configuration = new Migrations.Configuration();
				var migrator = new DbMigrator(configuration);
				migrator.Update();

If we would like to change model before executing InitialCreate we would get such error after running Add-Migration AddBlogUrl:

Unable to generate an explicit migration because the following explicit migrations are pending: [201704120750423_InitialCreate]. 
Apply the pending explicit migrations before attempting to generate a new explicit migration.

5.	Now we can add new column in the Blog class and execute in PM console:
Add-Migration AddBlogUrl

6. Again execute migrations from C# level.

7. Add new class Post, extend class Blog, generate new migrations and execute them.

8. Now we want introduce manual changes in 201704121034137_AddPostClass.cs.
   So introduce the changes, delete db and execute all migrations once again.
   We cannot use existing DB because migration 201704121034137_AddPostClass was executed already in step 7.

9. Data Motion / Custom SQL - add new field to Post class and add custom SQL. Generate and execute migration.
   


