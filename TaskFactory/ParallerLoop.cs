using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
    class ParallerLoop
    {
        public static Int64 GetDirecotryBytes(string path,string searchPattern,SearchOption searchOption) 
        {
            var files = Directory.EnumerateDirectories(path, searchPattern, searchOption);
            Int64 masterTotal = 0;

            ParallelLoopResult result = Parallel.ForEach<string, Int64>(files, () =>
            {
                return 0;
            },
            (file, loopState, index, taskLocalTotal) =>
            {
                
                Int64 fileLength = 0;
                FileStream fs = null;
                try
                {
                    fs = File.OpenRead(file);
                    fileLength = fs.Length;
                }
                catch (IOException)
                {
                    //DO nothing
                }
                finally
                {
                    if (fs != null) fs.Dispose();
                }
                return taskLocalTotal + fileLength;
            },
            taskLocalTotal =>
            {
                Interlocked.Add(ref masterTotal, taskLocalTotal);
            });
            
            return masterTotal;
        }
    }
}
