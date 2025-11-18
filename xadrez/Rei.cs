using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            var lin = posicao.linha;
            var col = posicao.coluna;
            Posicao pos = new Posicao(0, 0);

            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // JOGADA ESPECIAL ROQUE

            if (qteMovimentos==0 && !partida.xeque)
            {
                Posicao posT1 = new Posicao(lin, col + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(lin, col + 1);
                    Posicao p2 = new Posicao(lin, col + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[lin, col + 2] = true;
                    }
                }

                Posicao posT2 = new Posicao(lin, col - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(lin, col - 1);
                    Posicao p2 = new Posicao(lin, col - 2);
                    Posicao p3 = new Posicao(lin, col - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[lin, col - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
