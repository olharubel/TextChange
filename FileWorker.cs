using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TextChange
{
    class FileWorker
    {
        static public string[] ReadFromFile(string path)
        {
             
            string[] text = File.ReadAllLines(path);
            if(text.Length == 0)
            {
                throw new Exception("Text is empty!");
            }
            return text;
        }
    }
}
