using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ParallelDemos
{
    public class APMExceptionHandling
    {
        public static void Go()
        {
            WebRequest webRequest = WebRequest.Create("http://github.com");
            webRequest.BeginGetResponse(ProcessWebResponse,webRequest);
            
        }

        private static void ProcessWebResponse(IAsyncResult ar)
        {
            WebRequest webRequest = (WebRequest)ar.AsyncState;
            WebResponse webResponse = null;
            try
            {
                webResponse = webRequest.EndGetResponse(ar);
                Console.WriteLine("Conent length:" + webResponse.ContentLength);
                Console.Read();
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.GetType() + ":" + ex.Message);
            }
            finally
            {
                if (webResponse != null) webResponse.Close();
            }
            
        }
    }
}
