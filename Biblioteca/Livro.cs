using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Biblioteca
{
    public class Livro
    {
        #region Atributos
        protected int ID;
        protected string _titulo;
        protected IEmprestavel categoria;
        #endregion
        #region Propriedades
        public int CodigoLivro
        {
            get
            {
                return this.ID;
            }
            private set
            {
                this.ID = value;
            }
        }
        public string Titulo
        {
            get { return this._titulo; }
            private set { this._titulo = value; }
        }
        public IEmprestavel Categoria
        {
            get { return this.categoria; }
            private set
            { }
        }
        #endregion

        #region Construtores
        public Livro(int iD, string titulo, int categoria)
        {
            CodigoLivro = iD;
            Titulo = titulo;
            if (categoria.Equals(1))
                this.categoria = new Fisico(this);
            else if (categoria.Equals(2))
                this.categoria = new Digital(this);

        }
        #endregion

        #region Regras de Negócio
        public Operacao emprestar(Usuario usuario, DateTime data)
        {
            return categoria.emprestar(usuario, data);
        }
        #endregion
    }
}
