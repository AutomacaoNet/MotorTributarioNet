using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class BaseCalculoIcms
    {
        private readonly TipoDesconto _tipoDesconto;

        public BaseCalculoIcms(TipoDesconto tipoDesconto)
        {
            _tipoDesconto = tipoDesconto;
        }

        public decimal ValorProduto { get; set; }

        public decimal Frete { get; set; }

        public decimal Seguro { get; set; }

        public decimal OutrasDespesas { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorIpi { get; set; }

        public decimal PercentualReducao { get; set; }

        public decimal QuantidadeProduto { get; set; }

        public decimal GetValorBaseCalculoIcms()
        {
            var baseCalculo = ValorProduto * QuantidadeProduto + ValorIpi + Frete + Seguro + OutrasDespesas;

            if (_tipoDesconto == TipoDesconto.Condincional)
            {
                var baseCalculoDescontoCondicional = baseCalculo + Desconto;

                return baseCalculoDescontoCondicional - baseCalculoDescontoCondicional * PercentualReducao / 100;
            }

            var baseCalculoDescontoIncondicional = baseCalculo - Desconto;

            return baseCalculoDescontoIncondicional - baseCalculoDescontoIncondicional * PercentualReducao/100;
        }
    }
}