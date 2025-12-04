using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    /// <summary>
    /// Testes para o cálculo do IBS Municipal (Imposto sobre Bens e Serviços - componente municipal)
    /// Reforma Tributária - LC 214/2025
    /// </summary>
    public class CalculoIbsMunicipalTest
    {
        [Fact]
        public void CalculoIbsMunicipalBasico()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS Municipal = 727.50 × 5% = 36.38 (arredondado)
            Assert.Equal(727.50m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(36.38m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalComDescontoIncondicional()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 - 100 (desconto) - PIS(14.85) - COFINS(68.40) - ICMS(162.00) = 654.75
            // IBS Municipal = 654.75 × 5% = 32.74 (arredondado)
            Assert.Equal(654.75m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(32.74m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalComFreteSeguroOutrasDespesas()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 + 50 + 20 + 30 - PIS(18.15) - COFINS(83.60) - ICMS(198.00) = 800.25
            // IBS Municipal = 800.25 × 4% = 32.01
            Assert.Equal(800.25m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(32.01m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalComFreteSeguroOutrasDespesasEDesconto()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 + 50 + 20 + 30 - 100 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS Municipal = 727.50 × 4% = 29.10
            Assert.Equal(727.50m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(29.10m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalApenasComponenteMunicipal()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS Municipal = 727.50 × 5% = 36.38 (arredondado)
            Assert.Equal(727.50m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(36.38m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalSemComponenteMunicipal()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS Municipal = 727.50 × 0% = 0.00 (sem componente municipal)
            Assert.Equal(727.50m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(0.00m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalComQuantidadeMaiorQueUm()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 - PIS(16.50) - COFINS(76.00) - ICMS(180.00) = 727.50
            // IBS Municipal = 727.50 × 5% = 36.38 (arredondado)
            Assert.Equal(727.50m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(36.38m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalSemPisCofinsIcms()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 1000 (sem deduções)
            // IBS Municipal = 1000 × 5% = 50.00
            Assert.Equal(1000.00m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(50.00m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalComValorDecimal()
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

            var resultadoCalculoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo: 157.89 - PIS(2.61) - COFINS(12.00) - ICMS(28.42) = 114.86
            // IBS Municipal = 114.86 × 3.75% = 4.31
            Assert.Equal(114.86m, resultadoCalculoIbsMunicipal.BaseCalculo);
            Assert.Equal(4.31m, resultadoCalculoIbsMunicipal.Valor);
        }

        [Fact]
        public void CalculoIbsMunicipalETotalComAmbosComponentes()
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

            // Calcula IBS UF e IBS Municipal separadamente
            var resultadoIbsUF = facade.CalculaIbs();
            var resultadoIbsMunicipal = facade.CalculaIbsMunicipal();

            // Base de cálculo deve ser a mesma para ambos
            Assert.Equal(resultadoIbsUF.BaseCalculo, resultadoIbsMunicipal.BaseCalculo);
            Assert.Equal(727.50m, resultadoIbsUF.BaseCalculo);

            // IBS UF = 727.50 × 10% = 72.75
            Assert.Equal(72.75m, resultadoIbsUF.Valor);

            // IBS Municipal = 727.50 × 5% = 36.38
            Assert.Equal(36.38m, resultadoIbsMunicipal.Valor);

            // IBS Total = IBS UF + IBS Municipal = 72.75 + 36.38 = 109.13
            var ibsTotal = resultadoIbsUF.Valor + resultadoIbsMunicipal.Valor;
            Assert.Equal(109.13m, ibsTotal);
        }
    }
}
