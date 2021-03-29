using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proyecto1
{
    class Nodos<T>
    {
        public static string _path = @"C:\Users\15109\temp\";
        
        public NodoVersiones<T> actual { get; set; }
        public NodoVersiones<T> ultimo { get; set; }
        public NodoVersiones<T> primero { get; set; }
        

        public string pathDirectorio()
        {
            return _path;
        }

        public Nodos()
        {
            primero = null;
            ultimo = null;
            actual = null;
        }
        public void agregarVersion(T version)
        {
            NodoVersiones<T> nuevaVersion = new NodoVersiones<T>(version);

            if (primero == null)
            {
                primero = nuevaVersion;
                ultimo = nuevaVersion;

            }
            else
            {
                ultimo.siguiente = nuevaVersion;
                ultimo = nuevaVersion;

            }
        }

        public string LeerArchivo(string nombretxt)
        {
            string line;
            string conten = "";
            try
            {
                StreamReader sr = new StreamReader(_path + nombretxt);
                line = sr.ReadLine();
                while (line != null)
                {
                    conten = conten+"\n" +line;
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
            return conten;
        }
    }
}
