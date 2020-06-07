using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Digital : IEmprestavel
    {
        private Livro lvr;
        public Digital(Livro lvr)
        {
            this.lvr = lvr;
        }
        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            return new Operacao(null, data);
        }
    }
}
