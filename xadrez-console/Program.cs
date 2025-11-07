using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Posicao P;

            //P = new Posicao(3, 4);
            //Console.WriteLine($"Posição {P}");
            //Console.ReadLine();

            //PosicaoXadrex pos = new PosicaoXadrex('a', 1);
            //Console.WriteLine(pos);
            //Console.WriteLine(pos.toPosicao());
            //Console.ReadLine();

            try
            {
                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.Write("Origem (Ex: C4): ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino (Ex: C6).: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
                
                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}