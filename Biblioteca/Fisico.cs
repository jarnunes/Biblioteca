using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Fisico : IEmprestavel
    {
        private Livro livroFisico;
        public Fisico(Livro lirs)
        {
            this.livroFisico = lirs;
        }
        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            return new Operacao(this.livroFisico, data);
        }
    }
}
