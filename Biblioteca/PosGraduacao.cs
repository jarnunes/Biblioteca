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

        public override Operacao emprestar(Livro livro, DateTime data)
        {
            Operacao aux;

            aux = new Operacao(livro, data, data.AddDays(7));

            StreamWriter emprestar = new StreamWriter(@"arquivos/EMPRESTIMOS.txt", true);
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
            String linhaAux = "";
            String[] dadosEmprestimos = new string[4];
            int livrosEmprestados = 0;
            bool situacao = true;

            linhaAux = emprestimos.ReadLine();

            while (linhaAux != null)
            {
                dadosEmprestimos = linhaAux.Split(";");

                if (int.Parse(dadosEmprestimos[0]) == this.codUser)
                {
                    livrosEmprestados++;
                    /*
                    if (DateTime.Now - DateTime.Parse(dadosEmprestimos[3]) > 7)
                    {
                        situacao = false;
                    }*/
                }

                linhaAux = emprestimos.ReadLine();
            }

            if (livrosEmprestados == 7)
                situacao = false;

            return situacao;
        }
    }
}
