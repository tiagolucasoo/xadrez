using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta),
                new PosicaoXadrex('c', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta),
                new PosicaoXadrex('c', 2).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta),
                new PosicaoXadrex('d', 2).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta),
                new PosicaoXadrex('e', 2).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta),
                new PosicaoXadrex('e', 1).toPosicao());
        }
    }
}
