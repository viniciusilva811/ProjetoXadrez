using ProjetoXadrez.tabuleiro;
using System;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);

            Tela.imprimirTabuleiro(tab);
            Console.ReadLine();

        }
    }
}
