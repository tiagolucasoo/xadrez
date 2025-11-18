using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        public bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {

            var lin = posicao.linha;
            var col = posicao.coluna;
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(lin - 1, col);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin - 2, col);
                if (tab.posicaoValida(pos) && livre(pos)
                    && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin - 1, col - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin - 1, col + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                if (lin == 3)
                {
                    Posicao esquerda = new Posicao(lin, col - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda)
                    && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(lin, col + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita)
                    && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.definirValores(lin + 1, col);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin + 2, col);
                if (tab.posicaoValida(pos) && livre(pos)
                    && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin + 1, col - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(lin + 1, col + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                if (lin == 4)
                {
                    Posicao esquerda = new Posicao(lin, col - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda)
                    && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(lin, col + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita)
                    && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }

                
            }


            return mat;
        }

    }
}
