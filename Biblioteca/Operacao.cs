using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Operacao
    {
        private Livro _livro;
        private DateTime _retirada;
        private DateTime _devolucao;
        private DateTime prox_retirada;
        private int difRetirada;
        private static string dadosOperacoes = @"..\..\..\arquivos\dadosOperacoesBibPOO.txt";


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
        public Operacao(Livro livro, DateTime data, int tipo, Usuario user)
        {
            if (tipo.Equals(0))
            {
                this.Livro = livro;
                this.Retirada = data;
            }
            else
            {
                StreamReader linha = new StreamReader(dadosOperacoes);
                String[] aux;
                DateTime retirada = default;
                while (linha.EndOfStream != true)
                {
                    aux = linha.ReadLine().Split(";");
                    if (aux[0].Equals(user.CodUser.ToString()) && livro.CodigoLivro.Equals(int.Parse(aux[1])) && aux[2].Equals("0"))
                    {
                        retirada = DateTime.Parse(aux[3]);
                    }
                }

                linha.Close();
                difRetirada = (int)data.Subtract(retirada.AddDays((user.LimiteDiasEmprestimo))).TotalDays;
                if (difRetirada < 0)
                    difRetirada = 0;

                this.Livro = livro;
                this.Devolucao = data;
            }
        }
        public Operacao(Livro livro, DateTime data)
        {
            this.Livro = livro;
            this.Devolucao = data;
            this.Retirada = DateTime.Now;
        }
        #endregion
        #region Regras de Negócio
        public override string ToString()
        {
            StringBuilder escrever = new StringBuilder();
            if (Livro.Categoria.ToString().Equals("Digital"))
            {
                escrever.AppendLine("----------------------");
                escrever.AppendLine("LIVRO CONSULTADO: \n");
                escrever.AppendLine($"Título: {Livro.Titulo}");
                escrever.AppendLine($"Código Livro: {Livro.CodigoLivro}");
                escrever.AppendLine($"Categoria: {Livro.Categoria.ToString()}");
                escrever.AppendLine($"Data Consulta: {this.Retirada.ToString("dd/MM/yyyy")}");
            }
            else
            {
                if (this.Retirada != default)
                {
                    escrever.AppendLine("----------------------");
                    escrever.AppendLine("LIVRO EMPRESTADO: \n");
                    escrever.AppendLine($"Título: {Livro.Titulo}");
                    escrever.AppendLine($"Código Livro: {Livro.CodigoLivro}");
                    escrever.AppendLine($"Categoria: {Livro.Categoria.ToString()}");
                    escrever.AppendLine($"Data retirada: {this.Retirada.ToString("dd/MM/yyyy")}");
                    escrever.AppendLine($"Data devolucao: {this.Devolucao.ToString("dd/MM/yyyy")}");
                }
                else
                {
                    escrever.AppendLine("----------------------");
                    escrever.AppendLine("LIVRO DEVOLVIDO: \n");
                    escrever.AppendLine($"Título: {Livro.Titulo}");
                    escrever.AppendLine($"Código Livro: {Livro.CodigoLivro}");
                    escrever.AppendLine($"Categoria: {Livro.Categoria.ToString()}");
                    escrever.AppendLine($"Data Devolucao: {this.Devolucao.ToString("dd/MM/yyyy")}");
                    escrever.AppendLine($"Livro entregue {this.difRetirada} dias atrasado");
                }

            }
            return escrever.ToString();
        }
        public static int difData(DateTime data)
        {
            return default;
        }
        #endregion
    }
}
