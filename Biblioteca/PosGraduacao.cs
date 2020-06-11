using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;

namespace Biblioteca
{
    /// <summary>
    /// Classe Pos-Graduacao. Especialicação da classe usuário
    /// </summary>
    public class PosGraduacao : Usuario
    {
        /// <summary>
        /// Construtor da classe PosGraduacao
        /// </summary>
        /// <param name="nome">Nome do usuario</param>
        /// <param name="codUser">Matricula usuario</param>
        /// <param name="tipo">int com o tipo do usuario</param>
        public PosGraduacao(string nome, int codUser, int tipo) : base(nome, codUser, tipo)
        {
            this.maxLivros = 7;
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
            if (situacao() && situacao(livro))
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
            foreach (Operacao p in this.emprestimos)
            {
                if (p.Livro.Equals(livro))
                {
                    empresti_dev.WriteLine($"{this.codUser};{livro.CodigoLivro};1;{data}");
                    aux = DateTime.Now.Subtract(p.Devolucao);

                    if (aux.TotalDays >= 0)
                    {
                        p.ProximaRetirada = DateTime.Now.AddDays(aux.TotalDays * 2);
                        this.situacaoUsuario = false;
                    }
                    else
                        this.situacaoUsuario = true;
                    this.operacoes.Add(p);
                    this.emprestimos.Remove(p);
                }
            }
            empresti_dev.Close();
            return (int)(aux.TotalDays);
        }
        /// <summary>
        /// Método para validar a situação de um aluno
        /// </summary>
        /// <returns>retorna true caso não tenha livros em atraso, e false caso esteja em atraso.</returns>
        public override bool situacao(Livro livro)
        {
            Boolean aux = false;
            foreach (Operacao item in emprestimos)
            {
                if (item.Livro.Equals(livro))
                {
                    aux = false;
                }
                else
                {
                    aux = true;
                }
            }

            if (this.emprestimos.Count < this.maxLivros)
                aux = true;
            else
                aux = false;

            return aux;
        }
        public override bool situacao()
        {
            if (this.emprestimos.Count < maxLivros)
                return true;
            else if (this.situacaoUsuario)
                return true;
            else
                return false;
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
