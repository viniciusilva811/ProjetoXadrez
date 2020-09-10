using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, CorPeca corPeca) : base(corPeca, tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}