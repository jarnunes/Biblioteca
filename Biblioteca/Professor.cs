using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Professor : Usuario
    {
        public Professor(string nome, int codUser) : base(nome, codUser)
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

        public override bool situacao()
        {
            throw new NotImplementedException();
        }
    }
}
