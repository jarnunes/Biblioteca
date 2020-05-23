using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public abstract class Usuario
    {
        protected int codUser;
        protected string nome;

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
        }

        public abstract Operacao emprestar(Livro livro, DateTime data);
        public abstract int devolver(Livro livro, DateTime data);
        public abstract bool situacao();
    }
}
