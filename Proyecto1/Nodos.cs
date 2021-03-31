using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proyecto1
{
    class Nodos<T>
    {
        public static string _path = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp\";
        
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

        /*Función que valida si los nodos se encuentran vacios*/
        public bool validarNodos()
        {
            bool NodoVacio;
            if (primero == null)
            {
                return NodoVacio = true;
            }
            else
            {
                return NodoVacio = false;
            }
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
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
            return conten;
        }

        /*Se crea Función que recorrera la lista del Nodo*/
        public Array recorre()
        {
            actual = primero;
            int contador = 0;
            while (actual != null)
            {
                contador++;
                actual = actual.siguiente;
            }

            actual = primero;
            string[] nuevaLista = new string[contador];

            int i = 0;
            while (actual != null)
            {
                Console.WriteLine(actual.dato);
                nuevaLista[i] = actual.dato.ToString();
                actual = actual.siguiente;
                i++;
            }
            return nuevaLista;
        }

        /*Se crea una función que servira como apoyo para reccorrer la lista del nodoenlazado
         */
        public string recorredeapoyo()
        {

            actual = primero;
            string nuevaLista = "";


            while (actual != null)
            {
                nuevaLista = actual.dato.ToString();
                actual = actual.siguiente;

            }

            return nuevaLista;

        }

        public bool CompararContenido(string contenidonuevo, string contenido_anterior)
        {

            var comparar = false;

            if (contenidonuevo.Equals(contenido_anterior))
            {
                comparar = true;
            }

            return comparar;

        }
    }
}
