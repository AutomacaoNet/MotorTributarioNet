using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class CalculoPisTest
    {

        [Fact]
        public void CalculoPis()
        {            
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.50m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(900.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(14.85m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComIpi()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1010.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.66m, decimal.Round(resultadoCalculoPis.Valor, 2));
        }

        [Fact]
        public void CalculoPisComIpiComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 10,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(910.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(15.02m, decimal.Round(resultadoCalculoPis.Valor, 2));
        }

        [Fact]
        public void CalculoPisComIpiZero()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0
            };

            var facade = new FacadeCalculadoraTributacao(produto);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(1000.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(16.50m, resultadoCalculoPis.Valor);
        }

        [Fact]
        public void CalculoPisComIpiZeroComDescontoIncondicional()
        {
            var produto = new Produto
            {
                PercentualPis = 1.65m,
                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                ValorIpi = 0,
                Desconto = 100.00m
            };

            var facade = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);

            var resultadoCalculoPis = facade.CalculaPis();

            Assert.Equal(900.00m, resultadoCalculoPis.BaseCalculo);
            Assert.Equal(14.85m, resultadoCalculoPis.Valor);
        }
        [Fact]
        public void CalculoPisSemIncidenciaICMSNaBaseDeCalculo()
        {
            var produto = new Produto()
            {
                Cst = MotorTributarioNet.Flags.Cst.Cst00,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualIcms = 12,
                PercentualPis = 1.65m,
                QuantidadeProduto = 1,
                ValorProduto = 15m,
                DeduzIcmsDaBaseDePisCofins = true
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaPis();

            Assert.Equal(13.20m, resultado.BaseCalculo);
            Assert.Equal(0.2178m, resultado.Valor);
        }

        [Fact]
        public void CalculoPisSemIncidenciaICMSNaBaseDeCalculoComFreteOutrasDespesasDesconto()
        {
            var produto = new Produto()
            {
                Cst = MotorTributarioNet.Flags.Cst.Cst00,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualIcms = 12,
                PercentualPis = 1.65m,
                QuantidadeProduto = 1,
                ValorProduto = 15.99m,
                Frete = 1.02m,
                Desconto = 0.85m,
                OutrasDespesas = 0.67m,
                DeduzIcmsDaBaseDePisCofins = true
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaPis();

            Assert.Equal(14.8104m, resultado.BaseCalculo);
            Assert.Equal(0.2443716m, resultado.Valor);
        }
        [Fact]
        public void CalculoPisComReducaoDeBaseDeCalculo()
        {
            var produto = new Produto()
            {
                CstPisCofins = CstPisCofins.Cst01,
                PercentualPis = 1.65m,
                QuantidadeProduto = 2,
                ValorProduto = 15.99m,
                PercentualReducaoPis = 30.2m,
            };

            var tributacao = new FacadeCalculadoraTributacao(produto, TipoDesconto.Incondicional);
            var resultado = tributacao.CalculaPis();

            Assert.Equal(22.32204m, resultado.BaseCalculo);
            Assert.Equal(0.36831366m, resultado.Valor);
        }
    }
}