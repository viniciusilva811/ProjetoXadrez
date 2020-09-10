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
            Tabuleiro tab = new Tabuleiro(8,8);

            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new Posicao(0, 0));
            tab.inserirPeca(new Torre(tab, CorPeca.Preta), new Posicao(1, 3));
            tab.inserirPeca(new Rei(tab, CorPeca.Preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();

        }
    }
}
