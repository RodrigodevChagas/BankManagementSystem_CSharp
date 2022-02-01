using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var Lista = new List<int>();

            Lista.AdicionarVarios(1, 3, 56, 7, 3, 2, 6, 435, 54, 54, 3, 432);

            for (int item = 0; item < Lista.Count; item++)
            {
                Console.WriteLine(Lista[item]);
            }
            Console.ReadLine();
        }
        static void TestandoLista() 
        {
            //Criando uma estrutura de lista e a ordenando por SALDO.
            var ListaDeContas = new List<ContaCorrente>();
            var ContaDoSeth = new ContaCorrente(2131, 31231);
            ContaDoSeth.Saldo = 10000;
            var ContaDoSet = new ContaCorrente(2131, 76431);
            ContaDoSet.Saldo = 1000;
            var ContaDoSe = new ContaCorrente(2131, 86731);
            ContaDoSe.Saldo = 100;
            var ContaDoS = new ContaCorrente(2131, 14731);
            ContaDoS.Saldo = 10;
            ListaDeContas.AddRange(new ContaCorrente[] { (ContaDoSeth),(ContaDoSet),(ContaDoSe),(ContaDoS)});

            ListaDeContas.Sort(new ComparaContaPorSaldo());

            for (int indice = 0; indice < ListaDeContas.Count; indice++)
            {
                Console.WriteLine($"{ListaDeContas[indice]}");
            }
        }
        static void Testandoarray()
        {
            //Criando uma estrutura de array
            int[] lista = new int[5];
            lista[0] = 10;
            lista[1] = 10;
            lista[2] = 10;
            lista[3] = 10;
            lista[4] = 10;

            //Usando estrutura de repetição para extrair media dos numeros da lista
            int contador = 0;
            for (int indice = 0; indice < lista.Length; indice++)
            {
                Console.WriteLine($"O valor da lista no indice {indice} é {lista[indice]}");
                contador += lista[indice];
            }
            int media = contador / lista.Length;
        }
        static void VencimentoDeDocumento()
        {
            DateTime data = new DateTime(2022, 3, 27);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = data - dataCorrente;
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);
        }
    }
}
