using tabuleiro;
using System;
using ProjetoXadrez.tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                Tela.imprimirTabuleiro(partida.tab);
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
    }
