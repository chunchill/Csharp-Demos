using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
   class Program
   {
      static void Main(string[] args)
      {
         
      }
   }

   enum SexOption
   {
      Male,
      Female
   }

   internal class Person
   {
      public SexOption Sex { get; set; }
      public string Name { get; set; }
   }

   /// <summary>
   /// Collection Vs List;List<T> is not designed to be easily extensible by subclassing it; 
   /// it is designed to be fast for internal implementations. 
   /// You'll notice the methods on it are not virtual and so cannot be overridden
   /// </summary>
   internal class Males : Collection<Person>
   {
      protected override void InsertItem(int index, Person item)
      {
         if (item.Sex == SexOption.Female)
         {
            item.Sex=SexOption.Male;
            item.Name = "Male-" + item.Name;
         }
        base.InsertItem(index,item);
      }
   }
}
