using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Nodos<T>
    {
        public T data { get; set; }
        public Nodos<T> actual { get; set; }
        public Nodos<T> siguiente { get; set; }

    }
}
