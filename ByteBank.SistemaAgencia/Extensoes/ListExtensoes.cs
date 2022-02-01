using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes 
    {
        public static void AdicionarVarios<T>( this List<T> Lista, params T[] items)
        {
            foreach (T item in items)
            {
                Lista.Add(item);
            }
        }
    }
}
