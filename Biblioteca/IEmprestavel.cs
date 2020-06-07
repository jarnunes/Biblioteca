using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public interface IEmprestavel
    {
        Operacao emprestar( Usuario usuario, DateTime data);
    }
}
