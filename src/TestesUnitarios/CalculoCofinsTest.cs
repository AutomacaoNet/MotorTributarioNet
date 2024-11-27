using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoCofinsTest
    {

        [Fact]
        public void CalculaCofins()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(6.50m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(5.85m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsComIpiZero()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(1000.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(6.50m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculaCofinsComIpiZeroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualCofins = 0.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoCofins = facade.CalculaCofins();

            Assert.Equal(900.00m, resultadoCalculoCofins.BaseCalculo);
            Assert.Equal(5.85m, resultadoCalculoCofins.Valor);
        }

        [Fact]
        public void CalculoCofinsSemIncidenciaICMSNaBaseDeCalculo()
        {
            var produto = new Produto()
            {
                Cst = MotorTributarioNet.Flags.Cst.Cst00,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualCofins = 7.6m,
                PercentualIcms = 12,
                QuantidadeProduto = 1,
                ValorProduto = 15m,
                DeduzIcmsDaBaseDePisCofins = true
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaCofins();

            Assert.Equal(13.20m, resultado.BaseCalculo);
            Assert.Equal(1.00m, resultado.Valor);
        }

        [Fact]
        public void CalculoCofinsSemIncidenciaICMSNaBaseDeCalculoComFreteOutrasDespesasDesconto()
        {
            var produto = new Produto()
            {
                Cst = MotorTributarioNet.Flags.Cst.Cst00,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualIcms = 12,
                PercentualCofins = 7.6m,
                QuantidadeProduto = 1,
                ValorProduto = 15.99m,
                Frete = 1.02m,
                Desconto = 0.85m,
                OutrasDespesas = 0.67m,
                DeduzIcmsDaBaseDePisCofins = true
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaCofins();

            Assert.Equal(14.81m, resultado.BaseCalculo);
            Assert.Equal(1.13m, resultado.Valor);
        }

        [Fact]
        public void CalculoCofinsComReducaoDeBaseDeCalculo()
        {
            var produto = new Produto()
            {
                CstPisCofins = CstPisCofins.Cst01,
                PercentualCofins = 7.6m,
                QuantidadeProduto = 2,
                ValorProduto = 15.99m,
                PercentualReducaoCofins = 30.2m,
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaCofins();

            Assert.Equal(22.32m, resultado.BaseCalculo);
            Assert.Equal(1.70m, resultado.Valor);
        }
    }
}