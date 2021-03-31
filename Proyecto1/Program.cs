﻿using System;

namespace Proyecto1
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            string codSys = "C:/";
            string comentario;
            string contenido;
            string nombreAr;
            Nodos<Repositorio> manejoAr = new Nodos<Repositorio>();
            
            Console.Write(codSys);
            op = Console.ReadLine();

            while (op != "exit")
            {

                switch (op)
                {
                    case "create":
                        Console.Write(manejoAr.pathDirectorio());
                        nombreAr = Console.ReadLine();
                        contenido = Convert.ToString(manejoAr.LeerArchivo(nombreAr));
                        /*Se agregó este nuevo bloque de if para validar si se almacenará o no un nodo*/
                        if (!manejoAr.validarNodos())
                        {
                            Console.WriteLine("La lista enlazada contiene datos");
                            string lista = manejoAr.recorredeapoyo();
                            string contenidoanterior = "";
                            int i = 0;
                            for (i = 0; i < 1; i++)
                            {
                                string[] nuevoRepositorio = lista.Split("%");
                                Repositorio ultimaVersion = new Repositorio(nuevoRepositorio[2], nuevoRepositorio[3]);
                                contenidoanterior = ultimaVersion.contenido.ToString();
                            }
                            Console.WriteLine(contenidoanterior.Substring(11));


                            if (!manejoAr.CompararContenido(contenido, contenidoanterior.Substring(11)))
                            {
                                Console.WriteLine("Se crea una nueva versión");
                                Console.Write(manejoAr.pathDirectorio() + "Ingrese un comentario para el repositorio: ");
                                comentario = Console.ReadLine();
                                manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                                Console.WriteLine("\n SE ACTUALIZA EL NODO\n");
                                manejoAr.recorre();

                            }
                            else
                            {
                                Console.WriteLine("La última versión no ha sufrido ningun cambio");
                            }

                        }
                        else
                        {
                            Console.WriteLine("La lista enlazada no contiene datos\nSe procede a crear un nuevo repositorio");
                            Console.Write(manejoAr.pathDirectorio() + "Ingrese un comentario para el repositorio: ");
                            comentario = Console.ReadLine();
                            manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                            Console.WriteLine("Se creo un nuevo nodo");
                            Console.WriteLine("Los datos que se encuentran en la lista son:\n");
                            manejoAr.recorre();
                        }
                        op = Console.ReadLine();
                        break;

                    case "read":
                        Console.Write(manejoAr.pathDirectorio());
                        nombreAr = Console.ReadLine();
                        Console.WriteLine(manejoAr.LeerArchivo(nombreAr));
                        op = Console.ReadLine();
                        break;
                    case "dir":
                        Opciones();
                        Console.Write(codSys);
                        op = Console.ReadLine();
                        break;
                    case "search":
                        break;
                    case "binnacle":
                        Console.WriteLine("\nDatos en Bitacora\n");
                        manejoAr.recorre();
                        op = Console.ReadLine();
                        break;
                    case "delete":
                        break;

                    default:
                        Console.Write("error de comando");
                        Console.Write(codSys);
                        op = Console.ReadLine();
                        break;

                }
            }
            
            
        }
        public static void Opciones()
        {
            Console.WriteLine("");
            Console.WriteLine("search:      Buscar un repositorio");
            Console.WriteLine("create:      Crea un repositorio");
            Console.WriteLine("binnacle:    Bitacora de registros del repositorio");
            Console.WriteLine("delete:      Borra un registro");
            Console.WriteLine("read:        Lee la version actual");
        }
    }
}
