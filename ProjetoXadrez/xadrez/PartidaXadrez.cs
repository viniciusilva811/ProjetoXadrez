using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private CorPeca jogadorAtual;

        public PartidaXadrez() 
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = CorPeca.Branca;
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.aumentarMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.inserirPeca(p, destino);
        }
        private void colocarPecas() 
        {
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('c', 1).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('a', 4).toPosicao());
            tab.inserirPeca(new Rei(tab, CorPeca.Branca), new PosicaoXadrez('b', 2).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('e', 6).toPosicao());
        }
    }
}
