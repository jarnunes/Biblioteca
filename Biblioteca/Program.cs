using Microsoft.VisualBasic;
using System;
using System.Collections;
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
        #region Leitura de arquivos
        private static string listUser = @"..\..\..\arquivos\dadosUsuariosPOO.txt";
        private static string listLivros = @"..\..\..\arquivos\dadosLivrosPOO.txt";
        private static string listOperacoes = @"..\..\..\arquivos\dadosOperacoesBibPOO.txt";
        #endregion

        /// <summary>
        /// Menu para mostrar ao usuário opções da biblioteca 
        /// </summary>
        /// <returns>retorna inteiro com opção escolhida</returns>
        public static void getOperacaos(List<Usuario> user)
        {
            Console.Clear();

            List<Operacao> opUsuarios = new List<Operacao>();
            StreamReader dadosOperacoes = new StreamReader(listOperacoes);
            Operacao auxOP;
            string[] aux;

            Console.Write("MATRICULA: ");
            int matricula = int.Parse(Console.ReadLine());
            if (searchUser(user, matricula) != default)
            {
                Usuario userOperacao = searchUser(user, matricula);
                while (dadosOperacoes.EndOfStream != true)
                {
                    aux = dadosOperacoes.ReadLine().Split(";");
                    if (int.Parse(aux[0]).Equals(matricula))
                    {
                        auxOP = new Operacao(searchBook(aux[1]), DateTime.Parse(aux[3]), int.Parse(aux[2]), userOperacao);
                        opUsuarios.Add(auxOP);
                    }
                }
                foreach (Operacao item in opUsuarios)
                {
                    if (item.Livro != null)
                        Console.WriteLine(item.ToString());
                }
            }
            dadosOperacoes.Close();
        }
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

        /// <summary>
        /// Menu com opções para o usuario
        /// </summary>
        /// <returns>inteiro com opcao escolhida pelo usuario</returns>
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
                Console.WriteLine("7 - Maior dif");
                Console.WriteLine("0 - Sair");

                op = int.Parse(Console.ReadKey().KeyChar.ToString());

                if (op < 0 && op > 7)
                    op = -1;

            } while (op == -1);
            return op;
        }
        /// <summary>
        /// Método para pesquisar por um usuario na lista de usuarios
        /// </summary>
        /// <param name="usuarios">Lista de usuarios</param>
        /// <param name="matricula">matricula do usuario</param>
        /// <returns></returns>
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
        /// <summary>
        /// Método para pesquisar por um livro no arquivo de livros
        /// </summary>
        /// <param name="codBook">Código do livro a ser procurado</param>
        /// <returns></returns>
        private static Livro searchBook(string codBook)
        {
            StreamReader aux = new StreamReader(listLivros);
            Livro emprestar;
            while (aux.EndOfStream != true)
            {
                string[] livro = aux.ReadLine().Split(";");
                if (livro[0].Equals(codBook))
                    return emprestar = new Livro(int.Parse(livro[0]), livro[1], int.Parse(livro[2]));
            }
            return default;
        }
        /// <summary>
        /// Metodo de MENU emprestar 
        /// </summary>
        /// <param name="user">Lista de usuarios cadastrados na biblioteca</param>
        /// <returns></returns>
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
                        Console.Clear();
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
        /// <summary>
        /// Método de MENU devolver.
        /// </summary>
        /// <param name="user">Lista de usuarios cadastrados na biblioteca</param>
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
        /// <summary>
        /// Método de MENU para obter situação de determinado usuario
        /// /// </summary>
        /// <param name="user"></param>
        public static void Situacao(List<Usuario> user)
        {
            Usuario aux = default;
            Console.Clear();
            Console.Write("MATRICULA: ");
            int matricula = int.Parse(Console.ReadLine());
            if (searchUser(user, matricula) != default)
            {
                Console.Clear();
                aux = searchUser(user, matricula);
                Console.WriteLine(aux.situacao());
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Método de MENU para mostrar livros emprestados  a determinado usuario
        /// </summary>
        /// <param name="user"></param>
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
        /// Método de MENU listar todos os livros da biblioteca.
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
                            Situacao(user);
                            Console.ReadKey();
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
                        case 7:
                            getOperacaos(user);
                            Console.ReadKey();
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
