using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCardInterface;

namespace ABCCard
{
    [Export(typeof(ICard))]
    public class ABCCard:ICard
    {
       public string GetCountInfo()
       {
          return "ABC Bank Of China";
       }

       public void SaveMoney(double money)
       {
          this.Money += money;
       }

       public void CheckOutMoney(double money)
       {
          this.Money -= money;
       }

       public double Money { get; set; }
    }
}
