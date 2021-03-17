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
            //Repositorio datos = new Repositorio();
            Console.Write(codSys);
            op = Console.ReadLine();

            while (op != "exit")
            {

                switch (op)
                {
                    case "create":
                        Console.Write(codSys + op);
                        comentario = Console.ReadLine();
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
        }
    }
}
