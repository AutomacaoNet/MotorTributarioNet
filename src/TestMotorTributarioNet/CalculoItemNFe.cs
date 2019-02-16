using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using TestCalculosTributarios.Entidade;


namespace TestCalculosTributarios
{
    [TestClass]
    public class CalculoItemNFe
    {
        [TestMethod]
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

            Assert.AreEqual(1000.00m, resultado.ValorBcIcms);
            Assert.AreEqual(170.00m, resultado.ValorIcms);

            Assert.AreEqual(50.00m, resultado.ValorIpi);

            Assert.AreEqual(30.00m, resultado.ValorCofins);
            Assert.AreEqual(16.50m, resultado.ValorPis);
        }

        [TestMethod]
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

            Assert.AreEqual(1000.00m, resultado.ValorBcIcms);
            Assert.AreEqual(170.00m, resultado.ValorIcms);

            Assert.AreEqual(50.00m, resultado.ValorIpi);

            Assert.AreEqual(30.00m, resultado.ValorCofins);
            Assert.AreEqual(16.50m, resultado.ValorPis);

            Assert.AreEqual(20.00m, resultado.Fcp);
            Assert.AreEqual(60.00m, resultado.ValorDifal);
            Assert.AreEqual(00.00m, resultado.ValorIcmsOrigem);
            Assert.AreEqual(60.00m, resultado.ValorIcmsDestino);

        }

        [TestMethod]
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

            Assert.AreEqual(1000.00m, resultado.ValorBcIcms);
            Assert.AreEqual(170.00m, resultado.ValorIcms);

            Assert.AreEqual(50.00m, resultado.ValorIpi);

            Assert.AreEqual(30.00m, resultado.ValorCofins);
            Assert.AreEqual(16.50m, resultado.ValorPis);

            Assert.AreEqual(100, resultado.ValorTributacaoFederal);
            Assert.AreEqual(200, resultado.ValorTributacaoFederalImportados);
            Assert.AreEqual(150, resultado.ValorTributacaoEstadual);
            Assert.AreEqual(0, resultado.ValorTributacaoMunicipal);
        }

        [TestMethod]
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
          

            Assert.AreEqual(30.00m, resultado.ValorCofins);
            Assert.AreEqual(16.50m, resultado.ValorPis);
            Assert.AreEqual(50.00m, resultado.ValorIss);
        }

        [TestMethod]
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


            Assert.AreEqual(30.00m, resultado.ValorCofins);
            Assert.AreEqual(16.50m, resultado.ValorPis);
            Assert.AreEqual(50.00m, resultado.ValorIss);

            Assert.AreEqual(16.50m, resultado.ValorRetIrrf);
            Assert.AreEqual(30.00m, resultado.ValorRetCofins);
            Assert.AreEqual(6.50m, resultado.ValorRetPis);
            Assert.AreEqual(110.00m, resultado.ValorRetInss);
            Assert.AreEqual(10.00m, resultado.ValorRetClss);
        }
    }
}
