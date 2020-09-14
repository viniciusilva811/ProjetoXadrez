using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez() 
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = CorPeca.Branca;
            finalizada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.aumentarMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.inserirPeca(p, destino);
            if (pecaCapturada != null) 
            {
                capturadas.Add(pecaCapturada);
            }
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

        public HashSet<Peca> pecasCapturadas(CorPeca corPeca) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) 
            {
                if (x.corPeca == corPeca) 
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(CorPeca corPeca) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.corPeca == corPeca)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(corPeca));
            return aux;
        }   

        public void colocarNovaPeca(char coluna, int linha, Peca peca) 
        {
            tab.inserirPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() 
        {
            colocarNovaPeca('d', 1, new Rei(tab, CorPeca.Branca));
            colocarNovaPeca('c', 1, new Torre(tab, CorPeca.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, CorPeca.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, CorPeca.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, CorPeca.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, CorPeca.Branca));

            colocarNovaPeca('d', 8, new Rei(tab, CorPeca.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, CorPeca.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, CorPeca.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, CorPeca.Preta));
            colocarNovaPeca('c', 7, new Torre(tab, CorPeca.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, CorPeca.Preta));

        }
    }
}
