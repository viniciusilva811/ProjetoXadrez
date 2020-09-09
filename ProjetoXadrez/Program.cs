using ProjetoXadrez.Tabuleiro;
using System;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao posi;

            posi = new Posicao(3, 4);

            Console.WriteLine("Posicao: " + posi);

            Console.ReadLine();

        }
    }
}
