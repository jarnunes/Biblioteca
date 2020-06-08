using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Classe abstrata Usuario extendida por todos os possiveis usuarios da biblioteca
    /// </summary>
    public abstract class Usuario
    {
        #region Atritubos
        protected static string dadosOperacoes = @"..\..\..\arquivos\dadosOperacoesBibPOO.txt";
        protected int codUser;
        protected string nome;
        protected int tipo;
        protected bool situacaoUsuario;
        protected List<Operacao> operacoes;
        protected List<Operacao> emprestimos;
        protected const int totalDiasBase = 7;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor da Classe usuário
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="codUser"></param>
        /// <param name="senha"></param>
        public Usuario(string nome, int codUser, int tipo)
        {
            this.nome = nome;
            this.codUser = codUser;
            this.tipo = tipo;
            operacoes = new List<Operacao>();
            emprestimos = new List<Operacao>();
        }
        #endregion

        #region Regras de Negócio
        public abstract Operacao emprestar(Livro livro, DateTime data);
        public abstract int devolver(Livro livro, DateTime data);
        public abstract bool situacao();
        public string relatorio()
        {
            StringBuilder relatorio = new StringBuilder();
            foreach (Operacao aux in this.operacoes)
            {
                relatorio.AppendLine($"Usuário: {this.nome}");
                relatorio.AppendLine($"Livro: {aux.Livro.ToString()}");
                relatorio.AppendLine($"Livro: {aux.Devolucao}");
            }
            return relatorio.ToString();
        }
        public abstract string getLivrosEmprestados();
        public abstract int getCodUser();
        #endregion
    }
}
