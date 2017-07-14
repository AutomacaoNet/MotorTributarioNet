using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class BaseCalculoPis
    {
        private readonly TipoDesconto _tipoDesconto;

        public BaseCalculoPis(TipoDesconto tipoDesconto)
        {
            _tipoDesconto = tipoDesconto;
        }

        public decimal ValorProduto { get; set; }

        public decimal Frete { get; set; }

        public decimal Seguro { get; set; }

        public decimal OutrasDespesas { get; set; }

        public decimal Desconto { get; set; }

        public decimal QuantidadeProduto { get; set; }

        public decimal GetValorBaseCalculoPis()
        {
            var baseCalculo = ValorProduto * QuantidadeProduto + Frete + Seguro + OutrasDespesas;

            if (_tipoDesconto == TipoDesconto.Condincional)
            {
                var baseCalculoDescontoCondicional = baseCalculo + Desconto;

                return baseCalculoDescontoCondicional;
            }

            var baseCalculoDescontoIncondicional = baseCalculo - Desconto;

            return baseCalculoDescontoIncondicional;
        }
    }
}