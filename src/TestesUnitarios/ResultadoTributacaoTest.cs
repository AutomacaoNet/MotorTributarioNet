using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using MotorTributarioNet.Util;
using TestCalculosTributarios.Entidade;
using Xunit;

namespace TestCalculosTributarios
{
    public class ResultadoTributacaoTest
    {
        #region ICMS
        [Fact]
        public void Testa_Calculo_CST00_Interestadual()
        {
            var produto = CriaObjetoProduto();

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterestadual, TipoPessoa.Juridica);

            var resultado = tributacao.Calcular();
            Assert.Equal(37.26m, resultado.ValorIcms);
        }
        #endregion

        #region FCP
        [Fact]
        public void Testa_Calculo_FCP_Interestadual()
        {
            var produto = CriaObjetoProduto();

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            Assert.Equal(2.07m, resultado.Fcp);
        }
        #endregion

        #region ICMS Desonerado

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

        #endregion

        #region ICMS Monofasico
        [Fact]
        public void Testa_Cst_02_Icms_Monofasico_Proprio()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 16.10m,
                AliquotaAdRemIcms = 1.2571m,
                Cst = MotorTributarioNet.Flags.Cst.Cst02
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorArredondado = resultado.ValorIcmsMonofasicoProprio.Arredondar();
            Assert.Equal(20.24m, valorArredondado);
        }

        [Fact]
        public void Testa_Cst_15_Valor_Icms_Monofasico_Retencao()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 14.04m,
                PercentualReducaoAliquotaAdRemIcms = 13.41m,
                PercentualBiodisel = 20m,
                AliquotaAdRemIcms = 0.9456m,
                PercentualOriginarioUf = 26.0420m,
                Cst = MotorTributarioNet.Flags.Cst.Cst15
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoRetencao = resultado.ValorIcmsMonofasicoRetencao.Arredondar();
            Assert.Equal(0.69m, valorIcmsMonofasicoRetencao);
        }

        [Fact]
        public void Testa_Cst_15_Valor_Icms_Monofasico_Proprio()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 14.04m,
                PercentualReducaoAliquotaAdRemIcms = 13.41m,
                PercentualBiodisel = 20m,
                AliquotaAdRemIcms = 0.9456m,
                PercentualOriginarioUf = 26.0420m,
                Cst = MotorTributarioNet.Flags.Cst.Cst15
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoProprio = resultado.ValorIcmsMonofasicoProprio.Arredondar();
            Assert.Equal(9.20m, valorIcmsMonofasicoProprio);
        }

        [Fact]
        public void Testa_Cst_53_Valor_Icms_Monofasico_Proprio()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 20.23m,
                AliquotaAdRemIcms = 0.9456m,
                PercentualOriginarioUf = 38m,
                Cst = MotorTributarioNet.Flags.Cst.Cst53
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoProprio = resultado.ValorIcmsMonofasicoProprio.Arredondar();
            Assert.Equal(11.86m, valorIcmsMonofasicoProprio);
        }

        [Fact]
        public void Testa_Cst_53_Valor_Icms_Operacao()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 20.23m,
                AliquotaAdRemIcms = 0.9456m,
                PercentualOriginarioUf = 38m,
                Cst = MotorTributarioNet.Flags.Cst.Cst53
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoOperacao = resultado.ValorIcmsMonofasicoOperacao.Arredondar();
            Assert.Equal(19.13m, valorIcmsMonofasicoOperacao);
        }

        [Fact]
        public void Testa_Cst_53_Icms_Monofasico_Diferido()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasico = 20.23m,
                AliquotaAdRemIcms = 0.9456m,
                PercentualOriginarioUf = 38m,
                Cst = MotorTributarioNet.Flags.Cst.Cst53
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoDiferido = resultado.ValorIcmsMonofasicoDiferido.Arredondar();
            Assert.Equal(7.27m, valorIcmsMonofasicoDiferido);
        }

        [Fact]
        public void Testa_Cst_61_Icms_Monofasico_Retido_Anteriormente()
        {
            var produto = new Produto
            {
                QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente = 13.37m,
                AliquotaAdRemIcmsRetidoAnteriormente = 0.9456m,
                Cst = MotorTributarioNet.Flags.Cst.Cst61
            };

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);
            var resultado = tributacao.Calcular();
            decimal valorIcmsMonofasicoRetidoAnteriormente = resultado.ValorIcmsMonofasicoRetidoAnteriormente.Arredondar();
            Assert.Equal(12.64m, valorIcmsMonofasicoRetidoAnteriormente);
        }

        #endregion

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