using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proyecto1
{//Se cera una clase global, con el fin de acceder a la lista enlazada y los paths en cualquier momento del sistema
    class Global
    {
        public static Nodos<Repositorio> manejoAr = new Nodos<Repositorio>();
        public static string _path = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp\";
        public static string nuevoPath ="";
        public static string NombreArch = "";
        public static string folderParh = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp";
        public static string _pathTexto = @"C:\Users\wilso\OneDrive\Escritorio\Mariano Galvez\Tercer año 2021\Primer Semestre\Programación 3\Proyecto 1\Proyecto1\temp\";
        
    }
}
