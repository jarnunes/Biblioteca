using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Biblioteca
{

    public class Program
    {
        //alteração kk
        static string listUser = @"..\..\..\arquivos\dadosUsuariosPOO.txt";
        static string listLivros = @"..\..\..\arquivos\dadosLivrosPOO.txt";
        /// <summary>
        /// Menu para mostrar ao usuário opções da biblioteca 
        /// </summary>
        /// <returns>retorna inteiro com opção escolhida</returns>
        public static List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            StreamReader arquivo = new StreamReader(listUser);
            Usuario novo = default;
            string[] linha;
            while (arquivo.EndOfStream != true)
            {
                linha = arquivo.ReadLine().Split(";");
                if (linha[2].Equals("0"))
                {
                    novo = new Graduacao(linha[1], int.Parse(linha[0]), int.Parse(linha[2]));
                    usuarios.Add(novo);
                }
                else if (linha[2].Equals("1"))
                {
                    novo = new PosGraduacao(linha[1], int.Parse(linha[0]), int.Parse(linha[2]));
                    usuarios.Add(novo);
                }
                else if (linha[2].Equals("2"))
                {
                    novo = new Professor(linha[1], int.Parse(linha[0]), int.Parse(linha[2]));
                    usuarios.Add(novo);
                }

            }
            arquivo.Close();
            return usuarios;
        }
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

                op = int.Parse(Console.ReadKey().KeyChar.ToString());

                if (op < 0 && op > 6)
                    op = -1;

            } while (op == -1);
            return op;
        }
        private static Usuario searchUser(List<Usuario> usuarios, int matricula)
        {
            Usuario quem = default;
            foreach (Usuario p in usuarios)
            {
                quem = usuarios.Find(p => p.CodUser == matricula);
                return quem;
            }
            return quem;
        }
        private static Livro searchBook(string codBook)
        {
            StreamReader aux = new StreamReader(listLivros);
            Livro emprestar;
            while (aux.EndOfStream != true)
            {
                if (aux.ReadLine().Split(";")[0].Equals(codBook))
                {
                    string[] livro = aux.ReadLine().Split(";");
                    return emprestar = new Livro(int.Parse(livro[0]), livro[1], int.Parse(livro[2]));
                }
            }
            return default;
        }
        public static Usuario Emprestar(List<Usuario> user)
        {
            int op = -1;
            Usuario aux = default;
            do
            {
                Console.Clear();
                Console.Write("MATRICULA: ");
                int matricula = int.Parse(Console.ReadLine());
                if (searchUser(user, matricula) != default)
                {
                    Console.Write("Código Livro: ");
                    string codigo = Console.ReadLine();
                    if (searchBook(codigo).CodigoLivro != default)
                    {
                        aux = searchUser(user, matricula);
                        Console.WriteLine(aux.emprestar(searchBook(codigo), DateTime.Now).ToString());
                    }

                    do
                    {
                        Console.WriteLine("Deseja realizar outra operação?");
                        Console.WriteLine("DIGITE:\n\t1 - para sim\n\t2 - para não");

                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out op) && op >= 1 && op <= 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nERRO! Digite um valor válido!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    } while (op != 1 && op != 2);
                }
            } while (op != 2);
            return aux;
        }
        public static void Devolver(List<Usuario> user)
        {
            int op = -1;
            Usuario aux = default;
            do
            {
                Console.Clear();
                Console.Write("MATRICULA: ");
                int matricula = int.Parse(Console.ReadLine());
                if (searchUser(user, matricula) != default && searchUser(user, matricula).getLivrosEmprestados() != null)
                {
                    Console.Write("Código Livro: ");
                    string codigo = Console.ReadLine();
                    {
                        aux = searchUser(user, matricula);
                        Console.WriteLine($"O livro foi entregue {aux.devolver(searchBook(codigo), DateTime.Now)} dias atrasado");
                    }

                    do
                    {
                        Console.WriteLine("Deseja realizar outra operação?");
                        Console.WriteLine("DIGITE:\n\t1 - para sim\n\t2 - para não");

                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out op) && op >= 1 && op <= 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nERRO! Digite um valor válido!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (op != 1 && op != 2);
                }
            } while (op != 2);

        }
        public static void Situacao() { }
        public static void LivrosEmprestados(List<Usuario> user)
        {

            Console.Clear();

            Usuario aux = default;

            Console.Write("MATRICULA: ");
            int matricula = int.Parse(Console.ReadLine());
            if (searchUser(user, matricula) != default)
            {
                aux = searchUser(user, matricula);
                Console.WriteLine(aux.getLivrosEmprestados());
            }


            Console.ReadKey();
        }
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

            livros = new StreamReader(listLivros);
            while (livros.EndOfStream != true)
            {
                aux = livros.ReadLine().Split(";");
                for (int i = 0; i < aux.Length; i++)
                {
                    if (aux[i].Contains(","))
                    {
                        string[] subString = aux[1].Split(",");
                        aux[1] = subString[1] + " " + subString[0];
                        Console.WriteLine($"{descricao[i]} : {aux[i]}");
                    }
                    else
                        Console.WriteLine($"{descricao[i]} : {aux[i]}");
                }
                Console.WriteLine("\n-----------------\n");
                aux.Initialize();
            }

            livros.Close();
            Console.WriteLine("Pressione Enter para voltar ao Menu inicial");
            Console.ReadKey();
        }
        /// <summary>
        /// Método para mostrar relatório com todos os livros já emprestados de um determinado usuário incluindo se foram entregues
        /// atrasados ou dentro do praso
        /// </summary>
        public static void Relatorio()
        {

        }
        /// <summary>
        /// Programa principal
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            List<Usuario> user = getUsuarios();
            int op = 0;
            do
            {
                try
                {
                    op = Menu();

                    switch (op)
                    {
                        case 1:
                            Emprestar(user);
                            break;
                        case 2:
                            Devolver(user);
                            break;
                        case 3:
                            Situacao();
                            break;
                        case 4:
                            LivrosEmprestados(user);
                            Console.ReadKey();
                            break;
                        case 5:
                            Acervo();
                            break;
                        case 6:
                            Relatorio();
                            break;
                        case 0:
                            Console.WriteLine("\nAté a próxima!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine("Usuário não encontrado"!);
                    Console.WriteLine(fEx.Message);
                    Console.ReadKey();
                }
                catch (NullReferenceException nREx)
                {
                    Console.WriteLine("Código inválido!");
                    Console.WriteLine(nREx.Message);
                    Console.ReadKey();
                }
            } while (op != 0);
        }

    }
}
