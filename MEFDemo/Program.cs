using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BankCardInterface;

namespace MEFDemo
{
   class Program
   {
      [ImportMany(typeof(ICard))]
      public IEnumerable<ICard> cards { get; set; }

      static void Main(string[] args)
      {
         Program pro = new Program();
         pro.Compose();
         foreach (var c in pro.cards)
         {
            Console.WriteLine(c.GetCountInfo());
         }
         Console.WriteLine("Done!");
         Console.Read();
      }

      private void Compose()
      {
         var catalog = new DirectoryCatalog("./");
         var container = new CompositionContainer(catalog);
         container.ComposeParts(this);
      }
   }
}
