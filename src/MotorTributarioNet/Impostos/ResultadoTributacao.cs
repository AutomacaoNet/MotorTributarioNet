//                      Projeto: Motor Tributario                                                  
//          Biblioteca C# para Cálculos Tributários Do Brasil
//                    NF-e, NFC-e, CT-e, SAT-Fiscal     
//                                                                                                                                           
//  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la 
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) 
// qualquer versão posterior.                                                   
//                                                                              
//  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              
//                                                                              
//  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          
// Você também pode obter uma copia da licença em:                              
// https://github.com/AutomacaoNet/MotorTributarioNet/blob/master/LICENSE                       


using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Impostos.Csts.Base;
using MotorTributarioNet.Impostos.Tributacoes;

namespace MotorTributarioNet.Impostos
{
    public class ResultadoTributacao
    {
        #region Impostos Privados  

        private TipoContribuinte TipoContribuinte { get; set; }
        private Crt CrtEmpresa { get; set; }
        private CstBase Icms { get; set; }
        private TributacaoPis Pis { get; set; }
        private TributacaoCofins Cofins { get; set; }
        private TributacaoIpi Ipi { get; set; }
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
        public decimal ValorPis { get; private set; }
        public decimal ValorCofins { get; private set; }
        public decimal ValorIpi { get; private set; }

        #endregion

        private readonly ITributavel _produtoTributavel;

        public ResultadoTributacao(ITributavel produtoTributavel, Crt CrtEmpresa, TipoContribuinte tipoContribuinte)
        {
            _produtoTributavel = produtoTributavel;
            this.CrtEmpresa = CrtEmpresa;
            TipoContribuinte = tipoContribuinte;
        }

        public ResultadoTributacao Calcular()
        {

            #region Calcular ICMS



            #endregion

            #region Calcular Pis/Cofins



            #endregion

            #region Calcular Ipi 



            #endregion

            return this;
        }

        private void calcularIcms()
        {
            if (CrtEmpresa == Crt.RegimeNormal)
            {
                switch (_produtoTributavel.Cst)
                {
                    case Cst.Cst00:
                        Icms = new Cst00();
                        Icms.Calcula(_produtoTributavel);
                        ValorBcIcms = ((Cst00)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst00)Icms).PercentualIcms;
                        ValorIcms = ((Cst00)Icms).ValorIcms;
                        break;
                    case Cst.Cst10:
                        Icms = new Cst10();
                        Icms.Calcula(_produtoTributavel);
                        ValorBcIcms = ((Cst10)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst10)Icms).PercentualIcms;
                        ValorIcms = ((Cst10)Icms).ValorIcms;
                        PercentualMva = ((Cst10)Icms).PercentualMva;
                        PercentualReducaoSt = ((Cst10)Icms).PercentualReducaoSt;
                        ValorBcIcmsSt = ((Cst10)Icms).ValorBcIcmsSt;
                        PercentualIcmsSt = ((Cst10)Icms).PercentualIcmsSt;
                        ValorIcmsSt = ((Cst10)Icms).ValorIcmsSt;
                        break;
                    case Cst.Cst20:
                        Icms = new Cst20();
                        Icms.Calcula(_produtoTributavel);
                        ValorBcIcms = ((Cst20)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst20)Icms).PercentualIcms;
                        ValorIcms = ((Cst20)Icms).ValorIcms;
                        PercentualReducao = ((Cst20)Icms).PercentualReducao;
                        break;
                    case Cst.Cst30:
                        Icms = new Cst30();
                        Icms.Calcula(_produtoTributavel);
                        PercentualMva = ((Cst30)Icms).PercentualMva;
                        PercentualReducaoSt = ((Cst30)Icms).PercentualReducaoSt;
                        ValorBcIcmsSt = ((Cst30)Icms).ValorBcIcmsSt;
                        PercentualIcmsSt = ((Cst30)Icms).PercentualIcmsSt;
                        ValorIcmsSt = ((Cst30)Icms).ValorIcmsSt;
                        break;
                    case Cst.Cst40:
                        Icms = new Cst40();
                        Icms.Calcula(_produtoTributavel);
                        ValorIcmsDesonerado = ((Cst40)Icms).ValorIcmsDesonerado;
                        break;
                    case Cst.Cst41:
                        Icms = new Cst41();
                        Icms.Calcula(_produtoTributavel);
                        break;
                    case Cst.Cst50:
                        Icms = new Cst50();
                        Icms.Calcula(_produtoTributavel);
                        break;
                    case Cst.Cst51:
                        Icms = new Cst51();
                        Icms.Calcula(_produtoTributavel);
                        ValorBcIcms = ((Cst51)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst51)Icms).PercentualIcms;
                        ValorIcms = ((Cst51)Icms).ValorIcms;
                        PercentualReducao = ((Cst51)Icms).PercentualReducao;
                        PercentualDiferimento = ((Cst51)Icms).PercentualDiferimento;
                        ValorIcmsDiferido = ((Cst51)Icms).ValorIcmsDiferido;
                        ValorIcmsOperacao = ((Cst51)Icms).ValorIcmsOperacao;
                        PercentualReducao = ((Cst51)Icms).PercentualReducao;
                        break;
                    case Cst.Cst60:
                        Icms = new Cst60();
                        Icms.Calcula(_produtoTributavel);
                        PercentualBcStRetido = ((Cst60)Icms).PercentualBcStRetido;
                        ValorBcStRetido = ((Cst60)Icms).ValorBcStRetido;
                        break;
                    case Cst.Cst70:
                        Icms = new Cst70();
                        Icms.Calcula(_produtoTributavel);
                        PercentualReducao = ((Cst70)Icms).PercentualReducao;
                        break;
                    case Cst.Cst90:
                        Icms = new Cst90();
                        Icms.Calcula(_produtoTributavel);
                        ValorBcIcms = ((Cst90)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst90)Icms).PercentualIcms;
                        ValorIcms = ((Cst90)Icms).ValorIcms;
                        PercentualMva = ((Cst90)Icms).PercentualMva;
                        PercentualReducaoSt = ((Cst90)Icms).PercentualReducaoSt;
                        ValorBcIcmsSt = ((Cst90)Icms).ValorBcIcmsSt;
                        PercentualIcmsSt = ((Cst90)Icms).PercentualIcmsSt;
                        ValorIcmsSt = ((Cst90)Icms).ValorIcmsSt;
                        PercentualReducaoIcmsBc = ((Cst90)Icms).PercentualReducaoIcmsBc;
                        PercentualCredito = ((Cst90)Icms).PercentualCredito;
                        ValorCredito = ((Cst90)Icms).ValorCredito;
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }

        private TributacaoIpi calcularIpi()
        {

            Ipi = new TributacaoIpi(_produtoTributavel, TipoDesconto.Condincional);
            ValorIpi = Ipi.Calcula().Valor;

            return null;
        }

        private TributacaoCofins calcularCofins()
        {


            Cofins = new TributacaoCofins(_produtoTributavel, TipoDesconto.Condincional);
            ValorCofins = Cofins.Calcula().Valor;

            return null;
        }

        private TributacaoPis calcularPis()
        {
            Pis = new TributacaoPis(_produtoTributavel, TipoDesconto.Condincional);
            ValorPis = Pis.Calcula().Valor;
            return null;
        }


        private TributacaoDifal calcularDifal()
        {

            return null;
        }

        private TributacaoIssqn calcularIssqn()
        {

            return null;
        }

        private bool cstGeraDifal(string cst, int tipoOperacao, int indIE)
        {
            return cst.Equals("00") || cst.Equals("20") || cst.Equals("40") || cst.Equals("41") || cst.Equals("60") || cst.Equals("102") || cst.Equals("103") || cst.Equals("400") || cst.Equals("500");
        }

    }
}
