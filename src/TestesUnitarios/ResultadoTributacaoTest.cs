using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using MotorTributarioNet.Util;
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

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Simples_Cst_20()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 3.50m,
                PercentualIcms = 12,
                PercentualReducao = 41.67m,
                Cst = MotorTributarioNet.Flags.Cst.Cst20
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BaseSimples);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(0.24m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Por_Dentro_Cst_20()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 3.50m,
                PercentualIcms = 12,
                PercentualReducao = 41.67m,
                Cst = MotorTributarioNet.Flags.Cst.Cst20
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BasePorDentro);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(0.20m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Simples_Cst_30()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 200,
                PercentualIcms = 20,
                Cst = MotorTributarioNet.Flags.Cst.Cst30
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BaseSimples);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(40m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Por_Dentro_Cst_30()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 200,
                PercentualIcms = 20,
                Cst = MotorTributarioNet.Flags.Cst.Cst30
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BasePorDentro);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(50m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Simples_Cst_40()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 200,
                PercentualIcms = 20,
                Cst = MotorTributarioNet.Flags.Cst.Cst40
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BaseSimples);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(40m, valorArredondado);
        }
        [Fact]
        public void Testa_ICSM_Desonerado_Base_Por_Dentro_Cst_40()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 200,
                PercentualIcms = 20,
                Cst = MotorTributarioNet.Flags.Cst.Cst40
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BasePorDentro);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(50m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Simples_Cst_70()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 3.50m,
                PercentualIcms = 12,
                PercentualReducao = 41.67m,
                Cst = MotorTributarioNet.Flags.Cst.Cst70
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BaseSimples);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(0.24m, valorArredondado);
        }

        [Fact]
        public void Testa_ICSM_Desonerado_Base_Por_Dentro_Cst_70()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1,
                ValorProduto = 3.50m,
                PercentualIcms = 12,
                PercentualReducao = 41.67m,
                Cst = MotorTributarioNet.Flags.Cst.Cst70
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica, tipoCalculoIcmsDesonerado: TipoCalculoIcmsDesonerado.BasePorDentro);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsDesonerado.Arredondar();
            Assert.Equal(0.20m, valorArredondado);
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