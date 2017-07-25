namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIbpt : IResultadoCalculoIbpt
    {
        public ResultadoCalculoIbpt(decimal impostoAproximadoFederal, decimal impostoAproximadoMunicipio, 
            decimal impostoAproximadoEstadual, decimal impostoAproximadoImportados, decimal baseCalculo)
        {
            TributacaoFederal = impostoAproximadoFederal;
            TributacaoEstadual = impostoAproximadoEstadual;
            TributacaoMunicipal = impostoAproximadoMunicipio;
            TributacaoFederalImportados = impostoAproximadoImportados;
            BaseCalculo = baseCalculo;
        }

        public decimal TributacaoFederal { get; set; }
        public decimal TributacaoFederalImportados { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal TributacaoEstadual { get; set; }
        public decimal TributacaoMunicipal { get; set; }
    }
}