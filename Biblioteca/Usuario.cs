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
        protected ArrayList livrosEmprestados;
        protected List<Operacao> operacoes = new List<Operacao>();

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
            this.livrosEmprestados = new ArrayList();
        }

        public abstract Operacao emprestar(Livro livro, DateTime data);
        public abstract int devolver(Livro livro, DateTime data);
        public abstract bool situacao();
    }
}
