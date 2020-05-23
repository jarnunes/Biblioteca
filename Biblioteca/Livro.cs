using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Livro
    {
        protected int ID;
        protected string titulo;
        protected string autor;
        protected IEmprestavel categoria;

        public Livro(int iD, string titulo, string autor, IEmprestavel categoria)
        {
            ID = iD;
            this.titulo = titulo;
            this.autor = autor;
            this.categoria = categoria;
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
            return categoria.emprestar(usuario, data);
        }
    }
}
