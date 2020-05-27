using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Operacao
    {
        private Livro livro;
        private DateTime retirada;
        private DateTime devolucao;
        private DateTime prox_retirada;

        public Operacao(Livro livro, DateTime retirada, DateTime devolucao)
        {
            this.livro = livro;
            this.retirada = retirada;
            this.devolucao = devolucao;
        }

        public override string ToString()
        {
            StringBuilder escrever = new StringBuilder();
            escrever.AppendLine($"{this.livro.getCodLivro()};{this.livro.getTipo()};{this.retirada}");
            return escrever.ToString();
        }
        public DateTime GetDataRetirada()
        {
            return this.retirada;
        }
        public DateTime GetDataDevolucao()
        {
            return this.devolucao;
        }
        public Livro GetLivro()
        {
            return this.livro;
        }
    }
}
