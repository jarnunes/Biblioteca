using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Biblioteca
{
    public class Livro
    {
        protected int ID;
        protected string titulo;
        protected IEmprestavel categoria;

        public Livro(int iD, string titulo, int categoria)
        {
            ID = iD;
            this.titulo = titulo;
            if (categoria.Equals(1))
                this.categoria = new Fisico(this);
            else if (categoria.Equals(2))
                this.categoria = new Digital(this);
        }
        public int getCodLivro()
        {
            return this.ID;
        }
        public IEmprestavel getTipo()
        {

            return this.categoria;
        }

        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            categoria.emprestar(this, usuario, data);

           Operacao aux = categoria.emprestar(usuario, data);

            aux.setLivro(this);
            return aux;
        }
    }
}
