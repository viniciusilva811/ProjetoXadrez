﻿using tabuleiro;
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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.inserirPeca(new Torre(tab, CorPeca.Preta), new Posicao(0, 0));
                tab.inserirPeca(new Torre(tab, CorPeca.Preta), new Posicao(1, 3));
                tab.inserirPeca(new Rei(tab, CorPeca.Preta), new Posicao(0, 2));
                tab.inserirPeca(new Torre(tab, CorPeca.Branca), new Posicao(3, 5));
                Tela.imprimirTabuleiro(tab);
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
    }
