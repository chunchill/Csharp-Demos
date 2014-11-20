using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EF6Demos
{
   class Program
   {
      static void Main(string[] args)
      {
         using (var db = new SchoolEntities())
         {
            // Create and save a new Blog 
            Console.Write("Enter a name for a new Department: ");
            var name = Console.ReadLine();

            var department = new Department { Name = name };
            db.Departments.Add(department);
            db.SaveChanges();

            // Display all Blogs from the database 
            var query = from d in db.Departments
                        orderby d.Key
                        select d;

            Console.WriteLine("All departments in the database:");
            foreach (var item in query)
            {
               Console.WriteLine(item.Name);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
         }
      }
   }

   public class SchoolEntities : DbContext
   {
      public SchoolEntities()
         : base("SchoolEntities")
      {
         Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolEntities>());
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Properties()
            .Where(p => p.Name == "Key")
            .Configure(p => p.IsKey());
         modelBuilder.Conventions.Add(new DataTime2Convention());
         //modelBuilder.Types()
         //   .Configure(c => c.ToTable(c.ClrType.Name));
      }

      public DbSet<Department> Departments { get; set; }


   }

   public class Department
   {
      // Primary key 
      public int Key { get; set; }
      public string Name { get; set; }

      // Navigation property 
      public virtual ICollection<Course> Courses { get; set; }
   }

   public class Course
   {
      // Primary key 
      public int Key { get; set; }

      public string Title { get; set; }
      public int Credits { get; set; }

      // Foreign key 
      public int DepartmentKey { get; set; }

      // Navigation properties 
      public virtual Department Department { get; set; }
   }

   public partial class OnlineCourse : Course
   {
      public string URL { get; set; }
   }

   public partial class OnsiteCourse : Course
   {
      //It's the complex type, it will generate to fields not a table
      // but all of the fields will start with the complex type's name
      public Details Details { get; set; }
   }

   public class Details
   {
      public System.DateTime Time { get; set; }
      public string Location { get; set; }
      public string Days { get; set; }
   }

   public class DataTime2Convention : Convention
   {
      public DataTime2Convention()
      {
         this.Properties<DateTime>()
            .Configure(p => p.HasColumnType("datetime2"));
      }
   }

   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
   public class NonUnicode : Attribute
   {
   }


}
