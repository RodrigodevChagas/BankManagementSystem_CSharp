using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparaContaPorSaldo : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == null || y == null) 
            {
                return 1;
            }
            if (x == y) { return 0; }

            return x.Saldo.CompareTo(y.Saldo);
        }
    }
}
