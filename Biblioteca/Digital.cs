using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Digital : IEmprestavel
    {
        private Livro livroDigital;
        public Digital(Livro lvr)
        {
            this.livroDigital = lvr;
        }

        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            return new Operacao(livroDigital, default);
        }

        public override string ToString()
        {
            return "Digital";
        }
    }
}
