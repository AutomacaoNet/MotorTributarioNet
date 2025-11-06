using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    /// <summary>
    /// Testes para o cálculo da CBS (Contribuição sobre Bens e Serviços)
    /// Reforma Tributária - LC 214/2025
    /// </summary>
    public class CalculoCbsTest
    {
        [Fact]
        public void CalculoCbsBasico()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // CBS = 727.50 × 8% = 58.20
            Assert.Equal(727.50m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(58.20m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 - 100 (desconto) - PIS(14.85) - COFINS(68.40) - ICMS(162.00) = 654.75
            // CBS = 654.75 × 8% = 52.38
            Assert.Equal(654.75m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(52.38m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComFreteSeguroOutrasDespesas()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Frete = 50.00m,
                Seguro = 20.00m,
                OutrasDespesas = 30.00m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 + 50 + 20 + 30 - PIS(18.15) - COFINS(83.60) - ICMS(198.00) = 800.25
            // CBS = 800.25 × 8% = 64.02
            Assert.Equal(800.25m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(64.02m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComFreteSeguroOutrasDespesasEDesconto()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Frete = 50.00m,
                Seguro = 20.00m,
                OutrasDespesas = 30.00m,
                Desconto = 100.00m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 + 50 + 20 + 30 - 100 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // CBS = 727.50 × 8% = 58.20
            Assert.Equal(727.50m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(58.20m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComAliquotaDiferente()
        {
            var produto = new Produto
            {
                PercentualCbs = 12.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // CBS = 727.50 × 12% = 87.30
            Assert.Equal(727.50m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(87.30m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComQuantidadeMaiorQueUm()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 10.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // CBS = 727.50 × 8% = 58.20
            Assert.Equal(727.50m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(58.20m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsSemPisCofinsIcms()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 0.00m,
                PercentualCofins = 0.00m,
                PercentualIcms = 0.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 1000 (sem deduções)
            // CBS = 1000 × 8% = 80.00
            Assert.Equal(1000.00m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(80.00m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsComValorDecimal()
        {
            var produto = new Produto
            {
                PercentualCbs = 8.50m,
                ValorProduto = 157.89m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();

            // Base de cálculo: 157.89 - PIS(2.61) - COFINS(12.00) - ICMS(28.42) = 114.86
            // CBS = 114.86 × 8.50% = 9.76
            Assert.Equal(114.86m, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(9.76m, resultadoCalculoCbs.Valor);
        }

        [Fact]
        public void CalculoCbsEIbsJuntos()
        {
            // Teste para verificar que IBS UF, IBS Municipal e CBS podem ser calculados juntos
            var produto = new Produto
            {
                PercentualCbs = 8.00m,
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCbs = facade.CalculaCbs();
            var resultadoCalculoIbsUF = facade.CalculaIbs();
            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Todos devem ter a mesma base de cálculo
            Assert.Equal(resultadoCalculoIbsUF.BaseCalculo, resultadoCalculoCbs.BaseCalculo);
            Assert.Equal(resultadoCalculoIbsMunicipal.BaseCalculo, resultadoCalculoCbs.BaseCalculo);

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            Assert.Equal(727.50m, resultadoCalculoCbs.BaseCalculo);

            // CBS = 727.50 × 8% = 58.20
            Assert.Equal(58.20m, resultadoCalculoCbs.Valor);

            // IBS UF = 727.50 × 10% = 72.75
            Assert.Equal(72.75m, resultadoCalculoIbsUF.Valor);

            // IBS Municipal = 727.50 × 5% = 36.38 (arredondado)
            Assert.Equal(36.38m, resultadoCalculoIbsMunicipal.Valor);

            // IBS Total = IBS UF + IBS Municipal = 72.75 + 36.38 = 109.13
            var ibsTotal = resultadoCalculoIbsUF.Valor + resultadoCalculoIbsMunicipal.Valor;
            Assert.Equal(109.13m, ibsTotal);
        }
    }
}
