using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proyecto1
{
    class Nodos<T>
    {
        public T data { get; set; }
        public Nodos<T> actual { get; set; }
        public Nodos<T> siguiente { get; set; }

        public void LeerArchivo()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
        }
    }
}
