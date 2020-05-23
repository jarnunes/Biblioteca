using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    class Fisico : Livro, IEmprestavel
    {
        public Fisico(int id, string titulo, string autor, IEmprestavel categoria) : base(id, titulo, autor, categoria)
        {

        }

        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            throw new NotImplementedException();
        }
    }
}
