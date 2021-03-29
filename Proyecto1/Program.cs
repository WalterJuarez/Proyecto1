using System;

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
            Nodos<string> manejoAr = new Nodos<string>();
            
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
                        Console.Write(manejoAr.pathDirectorio() + "comentario: ");
                        comentario = Console.ReadLine();
                        
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
