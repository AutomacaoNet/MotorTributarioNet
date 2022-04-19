using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using TestCalculosTributarios.Entidade;
using Xunit;


namespace TestCalculosTributarios
{
    public class CalculoItemNFe
    {
        [Fact]
        public void CalcularItemComUIcmsIpiPisCofins()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = false,

                CstPisCofins = CstPisCofins.Cst01,
                PercentualIcms = 17.00m,
                PercentualIpi = 5.00m,
                PercentualCofins = 3.00m,
                PercentualPis = 1.65m
            };


            ResultadoTributacao calculo = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Fisica);
            var resultado = calculo.Calcular();

            Assert.Equal(1000.00m, resultado.ValorBcIcms);
            Assert.Equal(170.00m, resultado.ValorIcms);

            Assert.Equal(50.00m, resultado.ValorIpi);

            Assert.Equal(30.00m, resultado.ValorCofins);
            Assert.Equal(16.50m, resultado.ValorPis);
        }

        [Fact]
        public void CalcularItemComUIcmsIpiPisCofinsDifal()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = false,

                Cst = MotorTributarioNet.Flags.Cst.Cst00,
                PercentualIcms = 17.00m,

                PercentualIpi = 5.00m,

                CstPisCofins = CstPisCofins.Cst01,
                PercentualCofins = 3.00m,
                PercentualPis = 1.65m,

                PercentualFcp = 02.00m,
                PercentualDifalInterna = 18.00m,
                PercentualDifalInterestadual = 12.00m
            };


            ResultadoTributacao calculo = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterestadual, TipoPessoa.Fisica);
            var resultado = calculo.Calcular();

            Assert.Equal(1000.00m, resultado.ValorBcIcms);
            Assert.Equal(170.00m, resultado.ValorIcms);

            Assert.Equal(50.00m, resultado.ValorIpi);

            Assert.Equal(30.00m, resultado.ValorCofins);
            Assert.Equal(16.50m, resultado.ValorPis);

            Assert.Equal(20.00m, resultado.Fcp);
            Assert.Equal(60.00m, resultado.ValorDifal);
            Assert.Equal(00.00m, resultado.ValorIcmsOrigem);
            Assert.Equal(60.00m, resultado.ValorIcmsDestino);

        }

        [Fact]
        public void CalcularItemComUIcmsIpiPisCofinsIbpt()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = false,

                CstPisCofins = CstPisCofins.Cst01,
                PercentualIcms = 17.00m,
                PercentualIpi = 5.00m,
                PercentualCofins = 3.00m,
                PercentualPis = 1.65m,

                PercentualFederal = 10,
                PercentualFederalImportados = 20,
                PercentualEstadual = 15,
                PercentualMunicipal = 0
            };


            ResultadoTributacao calculo = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Fisica);
            var resultado = calculo.Calcular();

            Assert.Equal(1000.00m, resultado.ValorBcIcms);
            Assert.Equal(170.00m, resultado.ValorIcms);

            Assert.Equal(50.00m, resultado.ValorIpi);

            Assert.Equal(30.00m, resultado.ValorCofins);
            Assert.Equal(16.50m, resultado.ValorPis);

            Assert.Equal(100, resultado.ValorTributacaoFederal);
            Assert.Equal(200, resultado.ValorTributacaoFederalImportados);
            Assert.Equal(150, resultado.ValorTributacaoEstadual);
            Assert.Equal(0, resultado.ValorTributacaoMunicipal);
        }

        [Fact]
        public void CalcularItemServico()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualIssqn = 5.00m,
                PercentualCofins = 3.00m,
                PercentualPis = 1.65m,
            };


            ResultadoTributacao calculo = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = calculo.Calcular();
          

            Assert.Equal(30.00m, resultado.ValorCofins);
            Assert.Equal(16.50m, resultado.ValorPis);
            Assert.Equal(50.00m, resultado.ValorIss);
        }

        [Fact]
        public void CalcularItemServicoComRetencao()
        {
            var produto = new Produto
            {

                ValorProduto = 1000.00m,
                QuantidadeProduto = 1.000m,
                IsServico = true,
                CstPisCofins = CstPisCofins.Cst01,
                PercentualIssqn = 5.00m,
                PercentualCofins = 3.00m,
                PercentualPis = 1.65m,

                PercentualRetIrrf = 1.65m,
                PercentualRetCsll = 1.00m,
                PercentualRetCofins = 3.00m,
                PercentualRetPis = 0.65m,
                PercentualRetInss = 11.00m
            };


            ResultadoTributacao calculo = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = calculo.Calcular();


            Assert.Equal(30.00m, resultado.ValorCofins);
            Assert.Equal(16.50m, resultado.ValorPis);
            Assert.Equal(50.00m, resultado.ValorIss);

            Assert.Equal(16.50m, resultado.ValorRetIrrf);
            Assert.Equal(30.00m, resultado.ValorRetCofins);
            Assert.Equal(6.50m, resultado.ValorRetPis);
            Assert.Equal(110.00m, resultado.ValorRetInss);
            Assert.Equal(10.00m, resultado.ValorRetClss);
        }
    }
}
