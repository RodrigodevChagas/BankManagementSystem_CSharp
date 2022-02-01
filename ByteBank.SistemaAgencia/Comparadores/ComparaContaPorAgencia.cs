using ByteBank.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparaContaPorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == null) 
            {
                return 1;
            }
            if (y == null) 
            {
                return 1;
            }
            if (y == x) 
            {
                return 0;
            }


            if (x.Agencia < y.Agencia) 
            {
                return -1;
            }
            if (x.Agencia == y.Agencia) 
            {
                return 0;
            }
            
            return 1;
            
            //A implemtentação desse método pode ser resumida assim:
            //return x.Agencia.CompareTo(y.Agencia);

        }
    }
}
