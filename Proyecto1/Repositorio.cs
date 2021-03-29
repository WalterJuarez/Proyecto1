using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Repositorio
    {
        int contador = 0;
        string comentario;
        string contenido;
        string fecha = DateTime.Now.ToString();

        public Repositorio(string comentario, string contenido)
        {
            this.contador = contador + 1;
            this.comentario = comentario;
            this.contenido = contenido;
            this.fecha = fecha;
        }


    }
}
