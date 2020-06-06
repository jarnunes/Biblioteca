using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    interface IEmprestavel
    {
        Operacao emprestar(Usuario usuario, DateTime data);
    }
}
