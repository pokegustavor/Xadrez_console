using System;
using tabuleiro;
namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partida.Tab.peca(origem).MovimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);


                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                    }
                    catch(System.FormatException)
                    {
                        Console.WriteLine("Posição escolhida é inválida");
                        Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Erro inesperado! Tente novamente");
                        Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                    }
                }



            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
            }
            
        }
    }
}
