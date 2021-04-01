using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoVersiones<T>
    {
        public T dato { get; set; }
        public NodoVersiones<T> enlace { get; set; }

        public NodoVersiones(T dato)
        {
            this.dato = dato;
            this.enlace = null;
        }
    }
}
