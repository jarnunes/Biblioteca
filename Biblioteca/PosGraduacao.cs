using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Intrinsics.X86;

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

            Operacao aux;
            if (this.situacaoUsuario)
            {
                aux = new Operacao(livro, data, data.AddDays(7));
                StreamWriter emprestar = new StreamWriter(@"../../../arquivos/emprestimos.txt", true);
                emprestar.WriteLine($"{this.codUser};{aux.ToString()}");
                emprestar.Close();
                return aux;
            }
            else
            {
                return default;
            }
        }
        public override int devolver(Livro livro, DateTime data)
        {
            StreamWriter empresti_dev = new StreamWriter(@"../../../arquivos/emprestimos.txt", true);

            foreach (Operacao p in operacoes)
            {
                if (p.GetLivro().Equals(livro))
                {
                    empresti_dev.WriteLine($"{this.codUser};{livro.getCodLivro()};1;{data}");
                    operacoes.Remove(p);
                    TimeSpan aux = DateTime.Now.Subtract(p.GetDataDevolucao());
                    if (aux.TotalDays >= 0)
                        this.situacaoUsuario = true;
                    else
                        this.situacaoUsuario = false;
                }
            }
            empresti_dev.Close();
            return 0;
        }

        /// <summary>
        /// Método para validar a situação de um aluno
        /// </summary>
        /// <returns>retorna true caso não tenha livros em atraso, e false caso esteja em atraso.</returns>
        public override bool situacao()
        {
            return default;
        }
    }
}
