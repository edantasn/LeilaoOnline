using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(new double[] { 500, 600, 200 } )]
        public void QtdPermaneceZeroDadoQuePregaoNaoFoiIniciado(double[] lances)
        {
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in lances)
            {
                leilao.RecebeLance(fulano, valor);
            }

            var qtdEsperada = 0;
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }

    }
}
