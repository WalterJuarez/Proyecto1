using System;
using System.Collections.Generic;
using System.IO;

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

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(codSys);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            op = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Para iniciar el programa teclee init en consola\\");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string inicializar = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (inicializar.Equals("init"))
            {
                if (!Directory.Exists(Global.folderParh))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Directory.CreateDirectory(Global.folderParh);
                    Console.WriteLine("Se creó la siguiente ruta de acceso");
                    Console.WriteLine(Global.folderParh+"\\");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.WriteLine("La ruta de acceso ya existe y contiene los siguientes archvios\n");
                    string[] lita = new string[10];
                    lita = Directory.GetFiles(Global.folderParh);
                    int i = 0;
                        for (i = 0; i < lita.Length; i++)
                        {
                            Console.WriteLine(lita[i].ToString()+"\n");
                        }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Se recomienda eliminar la ruta anterior para crear una nueva y evitar problemas de compatibilidad, desea elminar? (si/no)");
                    Console.ForegroundColor = ConsoleColor.White;
                    string eliminar = Console.ReadLine();
                    string patheliminar;
                    if (eliminar.Equals("si"))
                    {
                        for (i = 0; i < lita.Length; i++)
                        { 
                            File.Delete(lita[i].ToString());
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Directory.Delete(Global.folderParh);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("La ruta fue elminada con exito, presione enter para crear una nueva");
                        string espera = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Directory.CreateDirectory(Global.folderParh);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Se creó la siguiente ruta de acceso");
                        Console.WriteLine(Global.folderParh + "\\");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("La ruta de acceso que se utilizará es");
                        Console.WriteLine(Global.folderParh + "\\");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\nIngrese el nombre del txt que desea crear: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Global.NombreArch = Console.ReadLine()+".txt";
                    Global.nuevoPath = Global._pathTexto + Global.NombreArch;
                    StreamWriter sw = new StreamWriter(Global.nuevoPath, true);
                    sw.Close();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Archivo Creado");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No se ha encontrado el archivo");
                }

                while (op != "exit")
                {

                    switch (op)

                    {
                        case "create":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            contenido = Convert.ToString(Global.manejoAr.LeerArchivo(Global.NombreArch));
                            Console.ForegroundColor = ConsoleColor.White;
                            /*Se agregó este nuevo bloque de if para validar si se almacenará o no un nodo*/
                            if (!Global.manejoAr.validarNodos())
                            {
                                string lista = Global.manejoAr.recorredeapoyo();
                                string contenidoanterior = "";
                                int i = 0;
                                for (i = 0; i < 1; i++)
                                {
                                    string[] nuevoRepositorio = lista.Split("%");
                                    Repositorio ultimaVersion = new Repositorio(null, null, nuevoRepositorio[2], nuevoRepositorio[3], nuevoRepositorio[4]);
                                    contenidoanterior = ultimaVersion.contenido.ToString();
                                }
                                if (!Global.manejoAr.CompararContenido(contenido, contenidoanterior.Substring(11)))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine(Global.nuevoPath + "\\" + "En el archivo txt existe una modificación, se crea una nueva versión, por favor presione Enter");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(Global.nuevoPath + "\\" + "Ingrese un comentario para el repositorio\\");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    comentario = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Global.manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine(Global.nuevoPath + "\\" + "Se actualiza el nodo exitosamente");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("El txt no sufrio ninguna modificación");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(Global.nuevoPath + "\\" + "Ingrese un comentario para el repositorio\\");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                comentario = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Global.manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(Global.nuevoPath + "\\" + "Se almacenó el nodo exitosamente");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            op = Console.ReadLine();
                            break;

                        case "read":
                            Console.Write(Global.nuevoPath + "\\");
                            nombreAr = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(Global.manejoAr.LeerArchivo(nombreAr));
                            Console.ForegroundColor = ConsoleColor.White;
                            op = Console.ReadLine();
                            break;
                        case "dir":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Opciones();
                            Console.Write(codSys);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            op = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "search":
                            string version;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(Global.nuevoPath + "\\" + "Ingrese la versión que le interesa buscar\\");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            version = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            string nuevaLista = Global.manejoAr.BusquedaVersion(version);
                            int j = 0;
                            if (nuevaLista != null)
                            {
                                string[] nuevoArreglo = nuevaLista.Split("%");
                                for (j = 0; j < 1; j++)
                                {
                                    Repositorio ultimaVersion = new Repositorio(nuevoArreglo[0], nuevoArreglo[1], nuevoArreglo[2], nuevoArreglo[3], nuevoArreglo[4]);
                                    if (nuevoArreglo[4].Substring(8).Equals("1"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("\t" + ultimaVersion.contadorauxiliar.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.fechaapoyo.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.comentario.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.contenido.ToString());
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("LA VERSIÓN NO EXISTE");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                            op = Console.ReadLine();
                            break;
                        case "binnacle":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Global.manejoAr.recorre();
                            Console.ForegroundColor = ConsoleColor.White;
                            op = Console.ReadLine();
                            break;
                        case "delete":
                            string eliminar;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(Global.nuevoPath + "\\" + "Ingrese la versión que desea eliminar\\");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            version = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Global.manejoAr.eliminarNodo(Global.manejoAr.obtenerIndice(version) - 1);
                            op = Console.ReadLine();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            /*Console.Write("error de comando");*/
                            Console.Write(codSys);
                            op = Console.ReadLine();

                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("NO SE PUEDE INICIAR EL PROGRAMA");
            }
        }
        public static void Opciones()
        {
            Console.WriteLine("");
            Console.WriteLine("search:      Buscar un Repositorio");
            Console.WriteLine("create:      Crea un Repositorio");
            Console.WriteLine("binnacle:    Bitacora de Registros del Repositorio");
            Console.WriteLine("delete:      Borra un Registro");
            Console.WriteLine("read:        Lee la version actual");
        }
    }
}