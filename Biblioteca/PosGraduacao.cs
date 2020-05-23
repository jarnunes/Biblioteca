using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biblioteca
{
    class PosGraduacao : Usuario
    {
        public PosGraduacao(string nome, int codUser) : base(nome, codUser)
        {
        }

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
            return 0;
        }

        public override bool situacao()
        {

            StreamReader emprestimos = new StreamReader(@"");
            String[] dadosEmprestimos;
            int livrosEmprestados = 0;
            bool situacao = true;
            while (emprestimos.EndOfStream != true)
            {
                dadosEmprestimos = emprestimos.ReadLine().Split(";");

                if (int.Parse(dadosEmprestimos[0]) == this.codUser)
                {
                    livrosEmprestados++;
                }
            }

            if (livrosEmprestados == 7)
                situacao = false;

            return situacao;
        }
    }
}
