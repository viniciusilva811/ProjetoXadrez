using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public CorPeca corPeca { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(CorPeca corPeca, Tabuleiro tab)
        {
            this.posicao = null;
            this.corPeca = corPeca;
            this.qtdMovimentos = 0;
            this.tab = tab;
        }

        public abstract bool[,] movimentosPossiveis();
        
        public void aumentarMovimentos() 
        {
            qtdMovimentos++;
        }
    }
}
