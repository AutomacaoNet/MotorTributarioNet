using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts;

namespace MotorTributarioNet.Impostos
{
    public class ResultadoTributacao
    {
        #region Impostos Privados

        private Cst00 Cst00 { get; set; }
        private Cst10 Cst10 { get; set; }
        private Cst20 Cst20 { get; set; }
        private Cst30 Cst30 { get; set; }
        private Cst40 Cst40 { get; set; }
        private Cst41 Cst41 { get; set; }
        private Cst50 Cst50 { get; set; }
        private Cst51 Cst51 { get; set; }
        private Cst60 Cst60 { get; set; }
        private Cst70 Cst70 { get; set; }
        private Cst90 Cst90 { get; set; }

        #endregion

        #region Retorno/Cálculo Público

        public decimal PercentualReducao { get; private set; }
        public decimal PercentualIcms { get; private set; }
        public decimal PercentualCredito { get; private set; }
        public decimal PercentualReducaoSt { get; private set; }
        public decimal PercentualMva { get; private set; }
        public decimal PercentualIcmsSt { get; private set; }
        public decimal PercentualReducaoIcmsBc { get; private set; }
        public decimal PercentualBcStRetido { get; private set; }
        public decimal PercentualDiferimento { get; private set; }
        public decimal ValorIcmsDiferido { get; private set; }
        public decimal ValorIcmsOperacao { get; private set; }

        public decimal ValorBcIcms { get; private set; }
        public decimal ValorIcms { get; private set; }
        public decimal ValorBcIcmsSt { get; private set; }
        public decimal ValorIcmsSt { get; private set; }
        public decimal ValorCredito { get; private set; }
        public decimal ValorBcStRetido { get; private set; }
        public decimal ValorIcmsDesonerado { get; set; }

        #endregion

        private readonly Cst _cst;
        private readonly ITributavel _produtoTributavel;

        public ResultadoTributacao(ITributavel produtoTributavel, Cst cst)
        {
            _cst = cst;
            _produtoTributavel = produtoTributavel;
        }

        public ResultadoTributacao Calcular()
        {
            switch (_cst)
            {
                case Cst.Cst00:
                    Cst00 = new Cst00();
                    Cst00.Calcula(_produtoTributavel);
                    ValorBcIcms = Cst00.ValorBcIcms;
                    PercentualIcms = Cst00.PercentualIcms;
                    ValorIcms = Cst00.ValorIcms;
                    break;
                case Cst.Cst10:
                    Cst10 = new Cst10();
                    Cst10.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst20:
                    Cst20 = new Cst20();
                    Cst20.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst30:
                    Cst30 = new Cst30();
                    Cst30.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst40:
                    Cst40 = new Cst40();
                    Cst40.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst41:
                    Cst41 = new Cst41();
                    Cst41.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst50:
                    Cst50 = new Cst50();
                    Cst50.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst51:
                    Cst51 = new Cst51();
                    Cst51.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst60:
                    Cst60 = new Cst60();
                    Cst60.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst70:
                    Cst70 = new Cst70();
                    Cst70.Calcula(_produtoTributavel);
                    break;
                case Cst.Cst90:
                    Cst90 = new Cst90();
                    Cst90.Calcula(_produtoTributavel);
                    break;
                default:
                    return this;
            }
            return this;
        }
    }
}













