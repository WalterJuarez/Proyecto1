using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoVersiones<T>
    {
        public T dato { get; set; }
        public NodoVersiones<T> siguiente { get; set; }

        public NodoVersiones(T dato)
        {
            this.dato = dato;
            this.siguiente = null;
        }
    }
}
