using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Repositorio
    {
        int contador = 0;
        string comentario;
        string fecha = DateTime.Now.ToString();

        public Repositorio(string comentario)
        {
            this.contador = contador + 1;
            this.comentario = comentario;
            this.fecha = fecha;
        }

    }
}
