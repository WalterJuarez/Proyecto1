using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Repositorio
    {
        int contador = 0 ;
        public string comentario { get; set; }
        public string contenido { get; set;}
        string fecha = DateTime.Now.ToString(); 

        public Repositorio(string comentario, string contenido)
        {
            this.contador = contador + 1;
            this.comentario = comentario;
            this.contenido = contenido;
            this.fecha = fecha;
        }

        public override string ToString()
        {
            return $"Versión No.:  {contador}" + "%" +
                   $"Fecha: {fecha}" + "%" +
                   $"Comentario: {comentario}" + "%" +
                   $"Contenido: {contenido}";

        }


    }
}
