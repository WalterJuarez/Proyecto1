using System;
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


            Console.Write(codSys);
            op = Console.ReadLine();

            Console.Write("Para iniciar el programa teclee init en consola\\");
            string inicializar = Console.ReadLine();
            string folderParh = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp";
            string _pathTexto = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp\";
            if (inicializar.Equals("init"))
            {
                if (!Directory.Exists(folderParh))
                {
                    Directory.CreateDirectory(folderParh);
                    Console.WriteLine(folderParh);

                }
                try
                {
                    Console.WriteLine("Ingrese el nombre del txt que desea crear");
                    Global.NombreArch = Console.ReadLine()+".txt";
                    Global.nuevoPath = _pathTexto + Global.NombreArch;
                    StreamWriter sw = new StreamWriter(Global.nuevoPath, true);
                    sw.Close();
                    Console.WriteLine("Archivo Creado");
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
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(Global.nuevoPath + "\\" + "En el archivo txt existe una modificación, se crea una nueva versión, por favor presione Enter");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(Global.nuevoPath + "\\" + "Ingrese un comentario para el repositorio\\");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    comentario = Console.ReadLine();
                                    Global.manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(Global.nuevoPath + "\\" + "Se actualiza el nodo exitosamente");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.WriteLine("El txt no sufrio ninguna modificación");
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(Global.nuevoPath + "\\" + "Ingrese un comentario para el repositorio\\");
                                Console.ForegroundColor = ConsoleColor.White;
                                comentario = Console.ReadLine();
                                Global.manejoAr.agregarVersion(new Repositorio(comentario, contenido));
                                Console.WriteLine(Global.nuevoPath + "\\" + "Se almacenó el nodo exitosamente");

                            }
                            op = Console.ReadLine();
                            break;

                        case "read":
                            Console.Write(Global.nuevoPath + "\\");
                            nombreAr = Console.ReadLine();
                            Console.WriteLine(Global.manejoAr.LeerArchivo(nombreAr));
                            op = Console.ReadLine();
                            break;
                        case "dir":
                            Opciones();
                            Console.Write(codSys);
                            op = Console.ReadLine();
                            break;
                        case "search":
                            string version;
                            Console.Write(Global.nuevoPath + "\\" + "Ingrese la versión que le interesa buscar\\");
                            version = Console.ReadLine();
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
                                        Console.WriteLine("\t" + ultimaVersion.contadorauxiliar.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.fechaapoyo.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.comentario.ToString());
                                        Console.WriteLine("\t" + ultimaVersion.contenido.ToString());
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("LA VERSIÓN NO EXISTE");
                            }


                            op = Console.ReadLine();
                            break;
                        case "binnacle":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Global.manejoAr.recorre();
                            op = Console.ReadLine();
                            break;
                        case "delete":
                            string eliminar;
                            Console.Write(Global.nuevoPath + "\\" + "Ingrese la versión que desea eliminar\\");
                            version = Console.ReadLine();
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