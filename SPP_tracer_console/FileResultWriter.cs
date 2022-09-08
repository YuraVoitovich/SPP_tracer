using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    internal class FileResultWriter : IResultWriter
    {
        private string path;

        public FileResultWriter(string path)
        {
            this.path = path;
        }

        public void WriteResult(string result)
        {
            
            using (FileStream fs = File.OpenWrite(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(result);
                fs.Write(info, 0, info.Length);
            }
          
        }
    }
}
