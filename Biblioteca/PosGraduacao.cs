using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Intrinsics.X86;

namespace Biblioteca
{
    public class PosGraduacao : Usuario
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
            Operacao aux = livro.emprestar(this, data.AddDays(totalDiasBase));
            this.operacoes.Add(aux);
            StreamWriter emprestar = new StreamWriter(dadosOperacoes, true);
            emprestar.WriteLine($"{this.codUser};{livro.CodigoLivro};0;{DateTime.Now.ToString("dd/MM/yyyy")}"); //Atenção à esta linha
            emprestar.Close();
            return aux;
        }
        public void proximaRetirada(DateTime data)
        {
            //Uma opção verificar o total de livros que estão no vet situação 
            //além disso, verificar também a data de entrega do primeiro livro
        }
        public override int devolver(Livro livro, DateTime data)
        {
            StreamWriter empresti_dev = new StreamWriter(dadosOperacoes, true);
            foreach (Operacao p in operacoes)
            {
                if (p.Livro.Equals(livro))
                {
                    empresti_dev.WriteLine($"{this.codUser};{livro.CodigoLivro};1;{data}");
                    operacoes.Remove(p);
                    TimeSpan aux = DateTime.Now.Subtract(p.Devolucao);
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
