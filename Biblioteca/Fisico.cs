using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Fisico : IEmprestavel
    {
        int teste = 0;
        private Livro livro;
        public Fisico(Livro lirs)
        {
            this.livro = lirs;
        }
        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            Operacao aux = new Operacao(this.livro, data);
            usuario.addListaOperacao(aux);
            throw new NotImplementedException();
        }
    }
}
