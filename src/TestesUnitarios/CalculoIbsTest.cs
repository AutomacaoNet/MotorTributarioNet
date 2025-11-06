using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    /// <summary>
    /// Testes para o cálculo do IBS (Imposto sobre Bens e Serviços)
    /// Reforma Tributária - LC 214/2025
    /// </summary>
    public class CalculoIbsTest
    {
        [Fact]
        public void CalculoIbsBasico()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS = 727.50 × (10% + 5%) / 100 = 727.50 × 0.15 = 109.125 → 109.12 (banker's rounding)
            Assert.Equal(727.50m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(109.12m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 - 100 (desconto) - PIS(14.85) - COFINS(68.40) - ICMS(162.00) = 654.75
            // IBS = 654.75 × 15% = 98.21
            Assert.Equal(654.75m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(98.21m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsComFreteSeguroOutrasDespesas()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 8.00m,
                PercentualIbsMunicipal = 4.00m,
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

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 + 50 + 20 + 30 - PIS(18.15) - COFINS(83.60) - ICMS(198.00) = 800.25
            // IBS = 800.25 × 12% = 96.03
            Assert.Equal(800.25m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(96.03m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsComFreteSeguroOutrasDespesasEDesconto()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 8.00m,
                PercentualIbsMunicipal = 4.00m,
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

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 + 50 + 20 + 30 - 100 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS = 727.50 × 12% = 87.30
            Assert.Equal(727.50m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(87.30m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsApenasComponenteEstadual()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 0.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS = 727.50 × 10% = 72.75
            Assert.Equal(727.50m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(72.75m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsApenasComponenteMunicipal()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 0.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS = 727.50 × 5% = 36.38 (arredondado)
            Assert.Equal(727.50m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(36.38m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsComQuantidadeMaiorQueUm()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 10.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS = 727.50 × 15% = 109.125 → 109.12 (banker's rounding)
            Assert.Equal(727.50m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(109.12m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsSemPisCofinsIcms()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 10.00m,
                PercentualIbsMunicipal = 5.00m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 0.00m,
                PercentualCofins = 0.00m,
                PercentualIcms = 0.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 1000 (sem deduções)
            // IBS = 1000 × 15% = 150.00
            Assert.Equal(1000.00m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(150.00m, resultadoCalculoIbs.Valor);
        }

        [Fact]
        public void CalculoIbsComValorDecimal()
        {
            var produto = new Produto
            {
                PercentualIbsUF = 8.50m,
                PercentualIbsMunicipal = 3.75m,
                ValorProduto = 157.89m,
                QuantidadeProduto = 1.000m,
                PercentualPis = 1.65m,
                PercentualCofins = 7.6m,
                PercentualIcms = 18.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoIbs = facade.CalculaIbs();

            // Base de cálculo: 157.89 - PIS(2.61) - COFINS(12.00) - ICMS(28.42) = 114.86
            // IBS = 114.86 × 12.25% = 14.07
            Assert.Equal(114.86m, resultadoCalculoIbs.BaseCalculo);
            Assert.Equal(14.07m, resultadoCalculoIbs.Valor);
        }
    }
}
