﻿using ProjetoXadrez.tabuleiro;
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

        public void aumentarMovimentos()
        {
            qtdMovimentos++;
        }

        public void diminuirMovimentos()
        {
            qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis() 
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++) 
            {
                for (int j = 0; j< tab.linhas; j++) 
                {
                    if (mat[i, j]) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) 
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }


        public abstract bool[,] movimentosPossiveis();
        
        
    }
}
