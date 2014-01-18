using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
   public class Demos
   {
      public static void Main()
      {
         Boolean createdNew;

         // Try to create a kernel object with the specified name 
         using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out createdNew))
         {
            if (createdNew)
            {
               // This thread created the kernel object so no other instance of this 
               // application must be running. Run the rest of the application here... 

               //TaskFactory.Go();
               //ParallerLoop.Go();
               //TimerDemo.Go();
               //APMExceptionHandling.Go();
               //RegisterdWaitHandlerDemo.Go();
               //APMWithTask.Go();
               //AsyncResultDemo.Go();
               //CancellationDemo.Go();
               //CancellationRegistDemo.Go();
               //ContinueWithDemo.Go();
               //ExecutionContextsDemo.Go();
               //ForegroundAndBackGroundThreads.Go();
               //QueueUserWorkItemDemo.Go();
               //TaskDemo.Go();
               //TaskFactory.Go();
               //TaskLogger.Go();
               //SimpleAwaitDemo.Go();
               //StrangeBehavior.Go();
               //new ThreadsSharingData().Go();
               SimpleWaitLockVsSimpleSpinLockDemo.Go();
               Console.Read();
            }
            else
            {
               // This thread opened an existing kernel object with the same string name; 
               // another instance of this application must be running now. 
               // There is nothing to do in here, let's just return from Main to terminate 
               // this second instance of the application. 
               Console.WriteLine("There is  an instance running already!");
               Console.Read();
            }
         }
      }



   }
}
