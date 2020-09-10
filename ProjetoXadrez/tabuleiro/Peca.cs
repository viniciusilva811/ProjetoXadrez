﻿using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }

        public CorPeca corPeca { get; protected set; }

        public int qtdMovimentos { get; protected set; }

        public Tabuleiro tab { get; protected set; }

        public Peca(Posicao posicao, CorPeca corPeca, Tabuleiro tab)
        {
            this.posicao = posicao;
            this.corPeca = corPeca;
            this.qtdMovimentos = 0;
            this.tab = tab;
        }
    }
}