﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proyecto1
{
    class Nodos<T>
    { 

        public NodoVersiones<T> actual { get; set; }
        public NodoVersiones<T> ultimo { get; set; }
        public NodoVersiones<T> primero { get; set; }
        public NodoVersiones<T> anterior { get; set; }



        public string pathDirectorio()
        {
            return Global._path;
        }

        public Nodos()
        {
            primero = null;
            ultimo = null;
            actual = null;
            anterior = null;
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


                nuevaVersion.siguiente = primero;
                primero = nuevaVersion;
                    

        }

        public string LeerArchivo(string nombretxt)
        {
            string line;
            string conten = "";
            try
            {
                StreamReader sr = new StreamReader(Global._path + nombretxt);
                line = sr.ReadLine();
                while (line != null)
                {
                    conten = conten + "\n" + line;
                    line = sr.ReadLine();
                }
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
            return conten;
        }

   
        public void recorre()
        {
            actual = primero;
            string lista = "";
            Console.WriteLine("\t\t\t\tDATOS ALMACENADOS EN LA BITACORA\n");
            Console.WriteLine("\t\t\tVersion No.\tFecha y Hora\t\tComentario\n");
            string[] nuevoRepositorio;
            Repositorio ultimaVersion;
            while (actual != null)
            {
                lista = actual.dato.ToString();
                nuevoRepositorio = lista.Split("%");
                ultimaVersion = new Repositorio(nuevoRepositorio[0], nuevoRepositorio[1], nuevoRepositorio[2], nuevoRepositorio[3], nuevoRepositorio[4]);
                if (nuevoRepositorio[4].Substring(8).Equals("1"))
                {
                    Console.WriteLine("\t\t\t\t" + ultimaVersion.contadorauxiliar.ToString().Substring(14) + "\t" + ultimaVersion.fechaapoyo.ToString().Substring(7) +
                        "\t" + ultimaVersion.comentario.ToString().Substring(12) + "\n");
                    actual = actual.siguiente;
                }
                else
                {
                    actual = actual.siguiente;
                }
            }

        }


        public string recorredeapoyo()
        {

            actual = primero;
            string nuevaLista = "";


            while (actual != null)
            {
                nuevaLista = actual.dato.ToString();
                actual = null;
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

        public int DevueveCorrelativoVersion()
        {
         
            actual = primero;
            string lista = "";
            string contenerVersion = "";
            string[] nuevoRepositorio = null;
            int contador = 0;
            while (actual != null)
            {
                int i = 0;
                for (i = 0; i < 1; i++)
                {
                    lista = actual.dato.ToString();
                    nuevoRepositorio = lista.Split("%");
                    Repositorio busquedaVersion = new Repositorio(nuevoRepositorio[0], null, null, null, null);
                    contenerVersion = busquedaVersion.contadorauxiliar.Substring(14);
                    if (contenerVersion.Equals("")){
                        contador = 0;
                    }
                    else
                    {
                        contador = Int32.Parse(contenerVersion);
                    }
                }
                actual = null;
            }
            return contador;
        }


        public string BusquedaVersion(string version)
        {
            actual = primero;
            string lista = "";
            string contenerVersion = "";
            string[] nuevoRepositorio = null;
            while (actual != null)
            {
                int i = 0;
                for (i = 0; i < 1; i++)
                {
                    lista = actual.dato.ToString();
                    nuevoRepositorio = lista.Split("%");
                    Repositorio busquedaVersion = new Repositorio(nuevoRepositorio[0], null, null, null, null);
                    contenerVersion = busquedaVersion.contadorauxiliar.Substring(14);
                    if (contenerVersion.Equals(version))
                    {
                        return lista;
                        break;
                    }
                }
                actual = actual.siguiente;
            }
            return null;
        }

        public int obtenerIndice(string version)
        {
            actual = primero;
            string lista = "";
            string contenerVersion = "";
            string[] nuevoRepositorio = null;
            bool encontrado = false;
            int contador = 0;

            while (actual != null && !encontrado)
            {
                int i = 0;
                lista = actual.dato.ToString();
                for (i = 0; i < 1; i++)
                {
                    nuevoRepositorio = lista.Split("%");
                    Repositorio busquedaVersion = new Repositorio(nuevoRepositorio[0], nuevoRepositorio[1], nuevoRepositorio[2], nuevoRepositorio[3], nuevoRepositorio[4]);
                    contenerVersion = busquedaVersion.contadorauxiliar.Substring(14);

                    if (contenerVersion.Equals(version))
                    {
                        encontrado = true;
                    }
                 
                }
                contador = contador + 1;
                actual = actual.siguiente;
            }

            
            return contador;
        }


        public void eliminarNodo( int index)
        {

            if (index == 0)
            {
                primero = primero.siguiente;
            }
            else
            {
                int contador = 0;
                NodoVersiones<T> temporal = primero;
                while (contador < index - 1)
                {
                    temporal = temporal.siguiente;
                    contador++;
                }
                temporal.siguiente = temporal.siguiente.siguiente;

            }

        }


        /*public void modificarNodo(T version, int index)
        {

            if (index == 0)
            {
   
                NodoVersiones<T> nuevoNodo = new NodoVersiones<T>(version);
                nuevoNodo.siguiente = primero;
                primero = nuevoNodo;
            }
            else
            {
                int contador = 0;
                NodoVersiones<T> temporal = primero;
                while (contador < index - 1)
                {
                    temporal = temporal.siguiente;
                    contador++;
                }
                temporal.siguiente = temporal.siguiente.siguiente;

            }

        }*/

    }
}
