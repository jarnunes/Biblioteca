using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biblioteca
{
    class PosGraduacao : Usuario
    {
        public PosGraduacao(string nome, int codUser) : base(nome, codUser) { }

        /// <summary>
        /// Método para empréstimos de livros para alunos de Pos-Graduação
        /// </summary>
        /// <param name="livro">Objeto livro emprestado</param>
        /// <param name="data">Data do empréstimo</param>
        /// <returns>Retorna a operação realizada por este método</returns>
        public override Operacao emprestar(Livro livro, DateTime data)
        {
            Operacao aux = new Operacao(livro, data, data.AddDays(7));

            StreamWriter emprestar = new StreamWriter(@"../../../arquivos/emprestimos.txt", true);
            emprestar.WriteLine($"{this.codUser};{aux.ToString()}");
            return aux;
        }
        public override int devolver(Livro livro, DateTime data)
        {
            foreach (var item in collection)
            {

            }
            for (int i = 0; i < this.operacoes.Count; i++)
            {
                if (operacoes[i].GetLivro().Equals(livro))
                {
                    TimeSpan diferenca = this.operacoes[i].GetDataDevolucao().Subtract(DateTime.Now);
                    if (diferenca.TotalDays >= 0)
                    {
                        this.operacoes.Add(livro);
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Método para validar a situação de um aluno
        /// </summary>
        /// <returns>retorna true caso não tenha livros em atraso, e false caso esteja em atraso.</returns>
        public override bool situacao()
        {
            for (int i = 0; i < this.operacoes.Count; i++)
            {
                TimeSpan diferenca = DateTime.Now.Subtract(this.operacoes[i].GetDataRetirada());
                if (diferenca.TotalDays > 7)
                {
                    return false;
                }
                /*else if (operacoes.Count > 7)
                {
                    return false;
                }*/
                else
                {
                    return true;
                }
            }
            return default;
        }
    }
}
