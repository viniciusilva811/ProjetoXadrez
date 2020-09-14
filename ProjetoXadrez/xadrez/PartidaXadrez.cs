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
        public bool xeque { get; private set; }

        public PartidaXadrez() 
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = CorPeca.Branca;
            finalizada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executarMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = tab.retirarPeca(origem);
            p.aumentarMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.inserirPeca(p, destino);
            if (pecaCapturada != null) 
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) 
        {
            Peca p = tab.retirarPeca(destino);
            p.diminuirMovimentos();
            if (pecaCapturada != null) 
            {
                tab.inserirPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.inserirPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino) 
        {
          Peca pecaCapturada =  executarMovimento(origem, destino);

            if (estaXeque(jogadorAtual)) 
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em xeque!");
            }

            if (estaXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
                else 
                {
                    xeque = false;
                }

            if (testeXeque(adversaria(jogadorAtual)))
            {
                finalizada = true;
            }
                else
                {
                    turno++;
                    mudaJogador();
                }

            
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

        private CorPeca adversaria(CorPeca corPeca)
        {
            if (corPeca == CorPeca.Branca)
            {
                return CorPeca.Preta;
            }
            else 
            {
                return CorPeca.Branca;
            }
        }

        private Peca rei(CorPeca corPeca) 
        {
            foreach(Peca x in pecasEmJogo(corPeca))
            {
                if (x is Rei) 
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaXeque(CorPeca corPeca) 
        {
            Peca R = rei(corPeca);

            foreach (Peca x in pecasEmJogo(adversaria(corPeca))) 
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]) 
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool testeXeque(CorPeca corPeca) 
        {
            if (!estaXeque(corPeca)) 
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(corPeca)) 
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++) 
                {
                    for (int j = 0; i < tab.colunas; j++) 
                    {
                        if (mat[i, j]) 
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimento(origem,destino);
                            bool testeXeque = estaXeque(corPeca);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) 
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
