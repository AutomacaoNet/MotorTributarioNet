using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class ResultadoTributacaoTest
    {
        [Fact]
        public void Testa_Calculo_CST00_Interestadual()
        {
            var produto = CriaObjetoProduto();

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterestadual, TipoPessoa.Juridica);

            var resultado = tributacao.Calcular();
            Assert.Equal(37.26m, resultado.ValorIcms);
        }

        [Fact]
        public void Testa_Calculo_FCP_Interestadual()
        {
            var produto = CriaObjetoProduto();

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            Assert.Equal(2.07m, resultado.Fcp);
        }

        private static Produto CriaObjetoProduto()
        {
            var produto = new Produto();

            produto.Cst = MotorTributarioNet.Flags.Cst.Cst00;
            produto.Desconto = 0;
            produto.Documento = Documento.NFe;
            produto.Frete = 0;
            produto.IsServico = false;
            produto.OutrasDespesas = 0;
            produto.PercentualCofins = 15;
            produto.PercentualFcp = 1m;
            produto.PercentualIcms = 18;
            produto.PercentualPis = 5;
            produto.PercentualReducao = 0;
            produto.QuantidadeProduto = 9;
            produto.Seguro = 0;
            produto.ValorProduto = 23;
            produto.PercentualDifalInterestadual = 12;
            produto.PercentualDifalInterna = 18;
            return produto;
        }
    }
}