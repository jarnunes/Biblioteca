using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    class Digital : Livro
    {
        public Digital(int id, string titulo, string autor, IEmprestavel categoria) : base(id, titulo, autor, categoria)
        {

        }
    }
}
