https://msdn.microsoft.com/en-us/library/jj193542(v=vs.113).aspx

https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx

https://msdn.microsoft.com/en-us/library/dn579398(v=vs.113).aspx

SCENARIO 1 Migrations without connecting to DB.

1.	Define DAO (model) in C#.

2.	In Package Manager Console execute: Enable-Migrations
This will create folder Migrations but without <timestamp>_InitialCreate.cs file.
NOTE: if the database would already create then the <timestamp>_InitialCreate.cs would be created!!!

3.	In Package Manager Console execute: Add-Migration InitialCreate
This will create the file without connecting to any database.
