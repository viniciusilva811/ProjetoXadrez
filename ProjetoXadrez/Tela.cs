using ProjetoXadrez.tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
    class Tela
    {
        public static void imprimirPartida(PartidaXadrez partida) 
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.finalizada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else 
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor... " + partida.jogadorAtual);

            }
        }

        public static void imprimirPecasCapturadas(PartidaXadrez partida) 
        {
            Console.WriteLine("Pecas capturadas: ");
            Console.Write("Brancas.. ");
            imprimirConjunto(partida.pecasCapturadas(CorPeca.Branca));
            Console.WriteLine();
            Console.Write("Pretas.. ");
            imprimirConjunto(partida.pecasCapturadas(CorPeca.Preta));
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) 
        {
            Console.Write("[");
            foreach (Peca x in conjunto) 
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                        imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                        else 
                        {
                            Console.BackgroundColor = fundoOriginal;
                        }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.corPeca == CorPeca.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor auxiliar = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = auxiliar;
                }

                Console.Write(" ");
            }
        }
    }
}

