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
        private void Init(Livro livro, DateTime data)
        {
            this.Livro = livro;
            this.Retirada = DateTime.Now;
            this.Devolucao = data;
        }

        public Operacao(Livro livro, DateTime retirada)
        {
            Init(livro, retirada);
        }
        #endregion
        #region Regras de Negócio

        public override string ToString()
        {
            StringBuilder escrever = new StringBuilder();
            escrever.AppendLine("LIVRO EMPRESTADO: \n");
            escrever.AppendLine($"Código Livro: {Livro.CodigoLivro}");
            escrever.AppendLine($"Categoria: {Livro.Categoria.ToString()}");
            escrever.AppendLine($"Data retirada: {this.Retirada.ToString("dd/MM/yyyy")}");
            escrever.AppendLine($"Data Devolucao: {this.Devolucao.ToString("dd/MM/yyyy")}");
            return escrever.ToString();
        }
        #endregion
    }
}
