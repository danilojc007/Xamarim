using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Banco
{
    public interface ICaminho
    {
        string GetPath(string NomeDoArquivo);
    }
}
