using System;
using System.IO;
using System.Net;
using System.Text;

namespace Biblioteca
{

    class Program
    {
        /// <summary>
        /// Menu para mostrar ao usuário opções da biblioteca 
        /// </summary>
        /// <returns>retorna inteiro com opção escolhida</returns>
        public static int Menu()
        {
            int op = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("===============BIBLIOTECA PUB===============");
                Console.WriteLine("MENU");
                Console.WriteLine("1 - Emprestar");
                Console.WriteLine("2 - Devolver");
                Console.WriteLine("3 - Situação usuário");
                Console.WriteLine("4 - Livros Emprestados");
                Console.WriteLine("5 - Acervo");
                Console.WriteLine("6 - Relatório");
                Console.WriteLine("0 - Sair");
                try
                {
                    op = int.Parse(Console.ReadKey().KeyChar.ToString());
                }
                catch (FormatException erro)
                {
                    Console.WriteLine("Formato inválido");
                    Console.WriteLine(erro.Message);
                }
                finally
                {
                    if (op < 0 && op > 6)
                        op = -1;
                }
            } while (op == -1);
            return op;
        }

        public static void Emprestar()
        {
            int op = -1;
            do
            {
                Console.Clear();


            } while (op.Equals(-1));
            Console.ReadKey();

        }
        public static void Devolver() { }
        public static void Situacao() { }
        public static void LivrosEmprestados() { }
        /// <summary>
        /// Método para ler um arquivo com a lista de livros e listar todos os livros da biblioteca.
        /// </summary>
        public static void Acervo()
        {
            Console.Clear();
            Console.WriteLine("==========ACERVO==========");
            string[] aux;
            string[] descricao = { "Código", "Título", "Categoria" };
            StreamReader livros = null;
            try
            {
                livros = new StreamReader(@"../../../arquivos/livros.txt");
                while (livros.EndOfStream != true)
                {
                    aux = livros.ReadLine().Split(";");
                    for (int i = 0; i < aux.Length; i++)
                    {
                        Console.WriteLine($"{descricao[i]} : {aux[i]}");
                    }
                    Console.WriteLine("\n-----------------\n");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
            }
            finally
            {
                livros.Close();
                Console.WriteLine("Pressione Enter para sair!");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Método para mostrar relatório com todos os livros já emprestados de um determinado usuário incluindo se foram entregues
        /// atrasados ou dentro do praso
        /// </summary>
        public static void Relatorio() { }
        /// <summary>
        /// Programa principal
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int op;
            do
            {
                op = Menu();

                switch (op)
                {
                    case 1:
                        Emprestar();
                        break;
                    case 2:
                        Devolver();
                        break;
                    case 3:
                        Situacao();
                        break;
                    case 4:
                        LivrosEmprestados();
                        break;
                    case 5:
                        Acervo();
                        break;
                    case 6:
                        Relatorio();
                        break;
                    default:
                        Console.WriteLine("Até a próxima!");
                        break;
                }
            } while (op != 0);
        }
    }
}
