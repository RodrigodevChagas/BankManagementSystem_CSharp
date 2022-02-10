using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Acessa o arquivo, cria o fluxo, abre e lê.
            var EnderecoDoArquivo = "contas.txt";
            
            //FileStream recebe o nome do arquivo e indica o que fazer com ele.
            
            //Using serve para fechar o arquivo após ter concluido o fluxo.
            //E funciona pois FileStream herda a interface IDisposable
            using (var FluxoDoArquivo = new FileStream(EnderecoDoArquivo, FileMode.Open))
            {
                //criando array para poder executar o buffer.
                var Buffer = new byte[1024];
                var numeroDeBytesLidos = -1;
                while ( numeroDeBytesLidos != 0)
                {
                //Usando o metodo Read para poder extrair os bytes lidos.
                    numeroDeBytesLidos = FluxoDoArquivo.Read(Buffer, 0, Buffer.Length);
                    EscreverBuffer(Buffer);
                    Console.ReadLine();

                }
            }

        }
        //EscrevendoBuffer
        static void EscreverBuffer(byte[] Buffer) 
        {
            var decodifica = Encoding.Default;
            var texto = decodifica.GetString(Buffer);

            Console.Write(texto);
            //foreach(var MeuByte in Buffer) 
            //{
            //    Console.Write(MeuByte);
            //    Console.Write(" ");

            //}
        }
        //Usando OrderBy e Lambda para ordenar as contas.
        static void OrdenandocomLambda()
        {
            var Lista = new List<ContaCorrente>()
            {
                new ContaCorrente(2131, 31231),
                null,
                new ContaCorrente(2131, 76431),
                new ContaCorrente(2131, 86731),
                new ContaCorrente(2131, 14731)
            };

            var ListaSemNulos =  Lista.Where(conta => conta != null);

            IOrderedEnumerable<ContaCorrente> NovaLista = ListaSemNulos.OrderBy(conta => conta.Numero);

                Console.WriteLine($"Contas ordenadas pelo OrderBy (Número da Conta): ");
            foreach (var conta in NovaLista) 
            {
                Console.WriteLine($"Numero da conta: {conta.Numero} e Numero da Agencia:{conta.Agencia}");
            }
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
