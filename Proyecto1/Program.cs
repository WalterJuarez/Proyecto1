using System;

namespace Proyecto1
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            string codSys = "C:/";
            //Repositorio datos = new Repositorio();
            Console.Write(codSys);
            op = Console.ReadLine();

            while (op != "exit")
            {

                switch (op)
                {
                    case "create":
                        Console.Write("prueba");
                        Console.Write(codSys);
                        op = Console.ReadLine();
                        break;
                    case "direc":
                        Opciones();
                        Console.Write(codSys);
                        op = Console.ReadLine();
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
