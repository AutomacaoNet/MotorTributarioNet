namespace MotorTributarioNet.Impostos.Csosns.Base
{
    public class CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;

        protected CalculaBaseCalculoBase(ITributavel tributavel)
        {
            _tributavel = tributavel;
        }

        protected decimal CalculaBaseDeCalculo()
        {
            var baseCalculo = _tributavel.ValorProduto * _tributavel.QuantidadeProduto +
                              _tributavel.Frete +
                              _tributavel.Seguro + _tributavel.OutrasDespesas;

            return baseCalculo;
        }
    }
}