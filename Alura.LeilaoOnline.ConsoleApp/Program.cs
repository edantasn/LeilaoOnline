using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double valorEsperado, double valorObtido)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperado == valorObtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Falhou! Esperado: {valorEsperado}, Obtido: {valorObtido}");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComVariosLances()
        {
            // Arrange - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            // Act - método sob test
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComApenasUmLance()
        {
            // Arrange - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            // Act - método sob test
            leilao.TerminaPregao();

            // Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
