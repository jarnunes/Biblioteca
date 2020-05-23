using System;

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

        public static void Emprestar() { }
        public static void Devolver() { }
        public static void Situacao() { }
        public static void LivrosEmprestados() { }
        public static void Acervo() { }
        public static void Relatorio() { }
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
