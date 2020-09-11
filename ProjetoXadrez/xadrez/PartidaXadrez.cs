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
        public int turno { get; private set; }
        public CorPeca jogadorAtual { get; private set; }
        public bool finalizada { get; private set; }

        public PartidaXadrez() 
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = CorPeca.Branca;
            finalizada = false;
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.aumentarMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.inserirPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino) 
        {
            executarMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos) 
        {
            if (tab.peca(pos) == null) 
            {
                throw new TabuleiroException("Não existe peça na posição escolhida...");
            }
            if (jogadorAtual != tab.peca(pos).corPeca) 
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua..");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) 
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino) 
        {
            if (!tab.peca(origem).podeMovePara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! ");
            }
        }


        private void mudaJogador()
        {
            if (jogadorAtual == CorPeca.Branca)
            {
                jogadorAtual = CorPeca.Preta;
            }
            else 
            {
                jogadorAtual = CorPeca.Branca;
            }
        }

        private void colocarPecas() 
        {
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.inserirPeca(new Rei(tab, CorPeca.Branca), new PosicaoXadrez('d', 1).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Branca), new PosicaoXadrez('e', 2).toPosicao());

            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.inserirPeca(new Rei(tab, CorPeca.Preta), new PosicaoXadrez('d', 8).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new PosicaoXadrez('e', 7).toPosicao());

        }
    }
}
