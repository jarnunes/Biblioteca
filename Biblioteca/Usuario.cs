using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Biblioteca
{
    public abstract class Usuario
    {
        protected int codUser;
        protected string nome;
        protected bool situacaoUsuario;
        protected List<Operacao> operacoes;

        /// <summary>
        /// Construtor da Classe usuário
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="codUser"></param>
        /// <param name="senha"></param>
        public Usuario(string nome, int codUser)
        {
            this.nome = nome;
            this.codUser = codUser;
            operacoes = new List<Operacao>();
        }

        public abstract Operacao emprestar(Livro livro, DateTime data);
        public abstract int devolver(Livro livro, DateTime data);
        public abstract bool situacao();

        public string relatorio()
        {
            StringBuilder relatorio = new StringBuilder();
            foreach (Operacao aux in this.operacoes)
            {
                relatorio.AppendLine($"Usuário: {this.nome}");
                relatorio.AppendLine($"Livro: {aux.GetLivro().ToString()}");
                relatorio.AppendLine($"Livro: {aux.GetDataDevolucao()}");
            }
            return relatorio.ToString();
        }
    }
}
