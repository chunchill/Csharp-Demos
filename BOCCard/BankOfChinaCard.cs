using System.ComponentModel.Composition;
using BankCardInterface;

namespace BOCCard
{
   [Export(typeof(ICard))]
   public class BankOfChinaCard : ICard
   {
      public string GetCountInfo()
      {
         return "Bank Of China";
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
