using System;
using System.IO;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Classe Professor: Especialicação da classe usuário
    /// </summary>
    public class Professor : Usuario
    {
        /// <summary>
        /// Construtor da classe Professor
        /// </summary>
        /// <param name="nome">Nome usuario</param>
        /// <param name="codUser">Matricula Usuario</param>
        /// <param name="tipo">Tipo usuario</param>
        public Professor(string nome, int codUser, int tipo) : base(nome, codUser, tipo)
        {
            this.maxLivros = 10;
            this.totalDiasBase *= 2;
        }
        /// <summary>
        /// Método para empréstimos de livros para alunos de Pos-Graduação
        /// </summary>
        /// <param name="livro">Objeto livro emprestado</param>
        /// <param name="data">Data do empréstimo</param>
        /// <returns>Retorna a operação realizada </returns>
        public override Operacao emprestar(Livro livro, DateTime data)
        {
            Operacao aux = default;
            if (situacao())
            {
                aux = livro.emprestar(this, data.AddDays(totalDiasBase));
                this.operacoes.Add(aux);
                if (aux.Devolucao != default)
                    this.emprestimos.Add(aux);
                StreamWriter emprestar = new StreamWriter(dadosOperacoes, true);
                emprestar.WriteLine($"{this.codUser};{livro.CodigoLivro};0;{DateTime.Now.ToString("dd/MM/yyyy")}");
                emprestar.Close();
            }
            return aux;
        }
        /// <summary>
        /// Método para devolver livros dos alunos de Pos-Graduação
        /// </summary>
        /// <param name="livro">Recebe o livro que sera devolvido</param>
        /// <param name="data">Data em que o livro foi entregue</param>
        /// <returns></returns>
        public override int devolver(Livro livro, DateTime data)
        {
            StreamWriter empresti_dev = new StreamWriter(dadosOperacoes, true);
            TimeSpan aux = default;
            int totDiasAtraso = 0;
            foreach (Operacao p in this.emprestimos)
            {
                Livro auslivro = p.Livro;
                if (auslivro.CodigoLivro.Equals(livro.CodigoLivro))
                {
                    empresti_dev.WriteLine($"{this.codUser};{livro.CodigoLivro};1;{data.ToString("dd/MM/yyyy")}");
                    empresti_dev.Close();
                    aux = DateTime.Now.Subtract(p.Devolucao);

                    if (aux.TotalDays > 0)
                    {
                        totDiasAtraso = (int)aux.TotalDays;
                    }
                    else
                    {
                        totDiasAtraso = 0;
                    }

                    this.operacoes.Add(p);
                    this.emprestimos.Remove(p);
                }
                return totDiasAtraso;
            }
            return totDiasAtraso;
        }
        /// <summary>
        /// Método para validar a situação de um aluno
        /// </summary>
        /// <returns>retorna true caso não tenha livros em atraso, e false caso esteja em atraso.</returns>
        public override bool situacao()
        {
            TimeSpan difData;
            bool situacao = false;
            foreach (Operacao item in emprestimos)
            {
                difData = DateTime.Now.Subtract(item.Retirada);
                if (difData.TotalDays <= 0)
                    situacao = true;
                else
                    situacao = false;

            }
            if (this.emprestimos.Count < maxLivros)
                situacao = true;

            return situacao;
        }
        /// <summary>
        /// Método para retornar todos os livros que estão emprestados com determinado usuário.
        /// </summary>
        /// <returns></returns>
        public override string getLivrosEmprestados()
        {
            StringBuilder livros = new StringBuilder();
            foreach (Operacao item in this.emprestimos)
            {
                livros.AppendLine(item.ToString());
                livros.AppendLine();
            }
            return livros.ToString();
        }
        public override string getOperacoes()
        {
            StringBuilder op = new StringBuilder();
            foreach (Operacao item in this.operacoes)
            {
                if (item.Livro != null)
                {
                    op.AppendLine(item.ToString());
                    op.AppendLine();
                }
            }
            return op.ToString();
        }
    }
}
