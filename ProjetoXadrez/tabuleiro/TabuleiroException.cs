using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXadrez.tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg) 
        {
        }
    }
}
