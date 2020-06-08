using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    class Graduacao : Usuario
    {
        public Graduacao(string nome, int codUser, int tipo) : base(nome, codUser, tipo)
        {
        }

        public override int devolver(Livro livro, DateTime data)
        {
            throw new NotImplementedException();
        }

        public override Operacao emprestar(Livro livro, DateTime data)
        {
            throw new NotImplementedException();
        }

        public override int getCodUser()
        {
            return this.codUser;
        }

        public override string getLivrosEmprestados()
        {
            throw new NotImplementedException();
        }

        public override bool situacao()
        {
            throw new NotImplementedException();
        }
    }
}
