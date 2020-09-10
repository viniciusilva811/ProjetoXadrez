using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, CorPeca corPeca) : base(corPeca, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
