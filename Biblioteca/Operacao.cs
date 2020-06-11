using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Operacao
    {
        private Livro _livro;
        private DateTime _retirada;
        private DateTime _devolucao;
        private DateTime prox_retirada;

        #region Propriedades
        public DateTime Retirada
        {
            get { return this._retirada; }
            private set { this._retirada = value; }
        }
        public DateTime Devolucao
        {
            get { return this._devolucao; }
            private set { this._devolucao = value; }
        }
        public DateTime ProximaRetirada
        {
            get { return this.prox_retirada; }
            set { this.prox_retirada = value; }
        }
        public Livro Livro
        {
            get { return this._livro; }
            private set
            {
                if (value != null)
                    this._livro = value;
            }
        }
        #endregion
        #region Construtores
        public Operacao(Livro livro, DateTime data, int tipo)
        {
            if (tipo.Equals(0))
            {
                this.Livro = livro;
                this.Retirada = data;
            }
            else
            {
                this.Livro = livro;
                this.Devolucao = data;
            }

        }
        public Operacao(Livro livro, DateTime data)
        {
            this.Livro = livro;
            this.Retirada = data;
        }
        #endregion
        #region Regras de Negócio
        public override string ToString()
        {
            StringBuilder escrever = new StringBuilder();
            StringBuilder dadosLivro = new StringBuilder();

            dadosLivro.AppendLine($"Título: {Livro.Titulo}");
            dadosLivro.AppendLine($"Código Livro: {Livro.CodigoLivro}");
            dadosLivro.AppendLine($"Categoria: {Livro.Categoria.ToString()}");
            dadosLivro.AppendLine($"Data retirada: {this.Retirada.ToString("dd/MM/yyyy")}");
            dadosLivro.AppendLine($"Data Devolucao: {this.Devolucao.ToString("dd/MM/yyyy")}");

            if (Livro.Categoria.ToString().Equals("Digital"))
            {
                escrever.AppendLine("LIVRO CONSULTADO: \n");
                escrever.AppendLine(dadosLivro.ToString());
            }
            else
            {
                escrever.AppendLine("LIVRO EMPRESTADO: \n");
                escrever.AppendLine(dadosLivro.ToString());
            }
            return escrever.ToString();
        }
        #endregion
    }
}
