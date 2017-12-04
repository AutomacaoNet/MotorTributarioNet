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
using MotorTributarioNet.Impostos.Csosns.Base;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Impostos.Csts.Base;
using MotorTributarioNet.Impostos.Tributacoes;

namespace MotorTributarioNet.Impostos
{
    public class ResultadoTributacao
    {
        #region Impostos Privados  

        private TipoContribuinte TipoContribuinte { get; set; }
        private TipoOperacao Operacao { get; set; }
        private Crt CrtEmpresa { get; set; }
        private CstBase icms { get; set; }
        private CsosnBase Csosn { get; set; }
        private TributacaoPis Pis { get; set; }
        private TributacaoCofins Cofins { get; set; }
        private TributacaoIpi Ipi { get; set; }
        private TributacaoDifal Difal { get; set; }
        private TributacaoIssqn Issqn { get; set; }

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
        public decimal ValorBcPis { get; private set; }
        public decimal ValorPis { get; private set; }
        public decimal ValorBcCofins { get; private set; }
        public decimal ValorCofins { get; private set; }
        public decimal ValorBcIpi { get; private set; }
        public decimal ValorIpi { get; private set; }

        public decimal ValorBcDifal { get; private set; }
        public decimal Fcp { get; private set; }
        public decimal ValorDifal { get; private set; }
        public decimal ValorIcmsOrigem { get; private set; }
        public decimal ValorIcmsDestino { get; private set; }

        public decimal ValorIss { get; private set; }
        public decimal BaseCalculoIss { get; private set; }
        public decimal PercentualIss { get; private set; }
        public decimal BaseCalculoInss { get; private set; }
        public decimal BaseCalculoIrrf { get; private set; }
        public decimal ValorRetCofins { get; private set; }
        public decimal ValorRetPis { get; private set; }
        public decimal ValorRetIrrf { get; private set; }
        public decimal ValorRetInss { get; private set; }

        #endregion

        private readonly ITributavel _produtoTributavel;

        public ResultadoTributacao(ITributavel produtoTributavel, Crt crtEmpresa, TipoOperacao operacao, TipoContribuinte tipoContribuinte)
        {
            _produtoTributavel = produtoTributavel;
            CrtEmpresa = crtEmpresa;
            Operacao = operacao;
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

        private CstBase CalcularIcms
        {
            get
            {
                if (CrtEmpresa == Crt.SimplesNacionalExecesso || CrtEmpresa == Crt.RegimeNormal)
                {
                    switch (_produtoTributavel.Cst)
                    {
                        case Cst.Cst00:
                            icms = new Cst00();
                            icms.Calcula(_produtoTributavel);
                            ValorBcIcms = ((Cst00)icms).ValorBcIcms;
                            PercentualIcms = ((Cst00)icms).PercentualIcms;
                            ValorIcms = ((Cst00)icms).ValorIcms;
                            break;
                        case Cst.Cst10:
                            icms = new Cst10();
                            icms.Calcula(_produtoTributavel);
                            ValorBcIcms = ((Cst10)icms).ValorBcIcms;
                            PercentualIcms = ((Cst10)icms).PercentualIcms;
                            ValorIcms = ((Cst10)icms).ValorIcms;
                            PercentualMva = ((Cst10)icms).PercentualMva;
                            PercentualReducaoSt = ((Cst10)icms).PercentualReducaoSt;
                            ValorBcIcmsSt = ((Cst10)icms).ValorBcIcmsSt;
                            PercentualIcmsSt = ((Cst10)icms).PercentualIcmsSt;
                            ValorIcmsSt = ((Cst10)icms).ValorIcmsSt;
                            break;
                        case Cst.Cst20:
                            icms = new Cst20();
                            icms.Calcula(_produtoTributavel);
                            ValorBcIcms = ((Cst20)icms).ValorBcIcms;
                            PercentualIcms = ((Cst20)icms).PercentualIcms;
                            ValorIcms = ((Cst20)icms).ValorIcms;
                            PercentualReducao = ((Cst20)icms).PercentualReducao;
                            break;
                        case Cst.Cst30:
                            icms = new Cst30();
                            icms.Calcula(_produtoTributavel);
                            PercentualMva = ((Cst30)icms).PercentualMva;
                            PercentualReducaoSt = ((Cst30)icms).PercentualReducaoSt;
                            ValorBcIcmsSt = ((Cst30)icms).ValorBcIcmsSt;
                            PercentualIcmsSt = ((Cst30)icms).PercentualIcmsSt;
                            ValorIcmsSt = ((Cst30)icms).ValorIcmsSt;
                            break;
                        case Cst.Cst40:
                            icms = new Cst40();
                            icms.Calcula(_produtoTributavel);
                            ValorIcmsDesonerado = ((Cst40)icms).ValorIcmsDesonerado;
                            break;
                        case Cst.Cst41:
                            icms = new Cst41();
                            icms.Calcula(_produtoTributavel);
                            break;
                        case Cst.Cst50:
                            icms = new Cst50();
                            icms.Calcula(_produtoTributavel);
                            break;
                        case Cst.Cst51:
                            icms = new Cst51();
                            icms.Calcula(_produtoTributavel);
                            ValorBcIcms = ((Cst51)icms).ValorBcIcms;
                            PercentualIcms = ((Cst51)icms).PercentualIcms;
                            ValorIcms = ((Cst51)icms).ValorIcms;
                            PercentualReducao = ((Cst51)icms).PercentualReducao;
                            PercentualDiferimento = ((Cst51)icms).PercentualDiferimento;
                            ValorIcmsDiferido = ((Cst51)icms).ValorIcmsDiferido;
                            ValorIcmsOperacao = ((Cst51)icms).ValorIcmsOperacao;
                            PercentualReducao = ((Cst51)icms).PercentualReducao;
                            break;
                        case Cst.Cst60:
                            icms = new Cst60();
                            icms.Calcula(_produtoTributavel);
                            PercentualBcStRetido = ((Cst60)icms).PercentualBcStRetido;
                            ValorBcStRetido = ((Cst60)icms).ValorBcStRetido;
                            break;
                        case Cst.Cst70:
                            icms = new Cst70();
                            icms.Calcula(_produtoTributavel);
                            PercentualReducao = ((Cst70)icms).PercentualReducao;
                            break;
                        case Cst.Cst90:
                            icms = new Cst90();
                            icms.Calcula(_produtoTributavel);
                            ValorBcIcms = ((Cst90)icms).ValorBcIcms;
                            PercentualIcms = ((Cst90)icms).PercentualIcms;
                            ValorIcms = ((Cst90)icms).ValorIcms;
                            PercentualMva = ((Cst90)icms).PercentualMva;
                            PercentualReducaoSt = ((Cst90)icms).PercentualReducaoSt;
                            ValorBcIcmsSt = ((Cst90)icms).ValorBcIcmsSt;
                            PercentualIcmsSt = ((Cst90)icms).PercentualIcmsSt;
                            ValorIcmsSt = ((Cst90)icms).ValorIcmsSt;
                            PercentualReducaoIcmsBc = ((Cst90)icms).PercentualReducaoIcmsBc;
                            PercentualCredito = ((Cst90)icms).PercentualCredito;
                            ValorCredito = ((Cst90)icms).ValorCredito;
                            break;
                        default:
                            break;
                    }
                }
                else
                {

                }

                return icms;
            }
        }

        private TributacaoDifal CalcularDifal
        {
            get
            {
                string cstCson = CrtEmpresa == Crt.SimplesNacional ? _produtoTributavel.Csosn.ToString() : _produtoTributavel.Cst.ToString();

                Difal = new TributacaoDifal(_produtoTributavel, TipoDesconto.Condincional);
                Fcp = decimal.Zero;
                ValorBcDifal = decimal.Zero;
                ValorDifal = decimal.Zero;
                ValorIcmsOrigem = decimal.Zero;
                ValorIcmsDestino = decimal.Zero;

                if (Operacao == TipoOperacao.OperacaoInterestadual
                       && CstGeraDifal(cstCson)
                       && _produtoTributavel.PercentualDifalInterna != 0
                       && _produtoTributavel.PercentualDifalInterestadual != 0)
                {
                    IResultadoCalculoDifal result = Difal.Calcula();
                    Fcp = result.Fcp;
                    ValorBcDifal = result.BaseCalculo;
                    ValorDifal = result.Difal;
                    ValorIcmsOrigem = result.ValorIcmsOrigem;
                    ValorIcmsDestino = result.ValorIcmsDestino;
                }
                return Difal;
            }
        }

        private TributacaoIpi CalcularIpi
        {
            get
            {
                Ipi = new TributacaoIpi(_produtoTributavel, TipoDesconto.Condincional);
                ValorIpi = decimal.Zero;
                ValorBcIpi = decimal.Zero;

                if (_produtoTributavel.CstIpi == CstIpi.Cst00
                    || _produtoTributavel.CstIpi == CstIpi.Cst49
                    || _produtoTributavel.CstIpi == CstIpi.Cst50
                    || _produtoTributavel.CstIpi == CstIpi.Cst99)
                {
                    IResultadoCalculoIpi result = Ipi.Calcula();
                    ValorIpi = result.Valor;
                    ValorBcIpi = result.BaseCalculo;
                }
                return Ipi;
            }
        }

        private TributacaoPis CalcularPis
        {
            get
            {
                Pis = new TributacaoPis(_produtoTributavel, TipoDesconto.Condincional);
                ValorPis = decimal.Zero;
                ValorBcPis = decimal.Zero;

                if (_produtoTributavel.CstPisCofins == CstPisCofins.Cst01
                   || _produtoTributavel.CstPisCofins == CstPisCofins.Cst02)
                {
                    IResultadoCalculoPis result = Pis.Calcula();
                    ValorPis = result.Valor;
                    ValorBcPis = result.BaseCalculo;
                }
                return Pis;
            }
        }

        private TributacaoCofins CalcularCofins
        {
            get
            {
                Cofins = new TributacaoCofins(_produtoTributavel, TipoDesconto.Condincional);
                ValorCofins = decimal.Zero;
                ValorBcCofins = decimal.Zero;

                if (_produtoTributavel.CstPisCofins == CstPisCofins.Cst01
                    || _produtoTributavel.CstPisCofins == CstPisCofins.Cst02)
                {
                    IResultadoCalculoCofins result = Cofins.Calcula();
                    ValorCofins = result.Valor;
                    ValorBcCofins = result.BaseCalculo;

                }
                return Cofins;
            }
        }
        
        private TributacaoIssqn CalcularIssqn(bool calcularRetencao)
        {
            Issqn = new TributacaoIssqn(_produtoTributavel, TipoDesconto.Condincional);
            IResultadoCalculoIssqn result = Issqn.Calcula(calcularRetencao);
            BaseCalculoInss = result.BaseCalculoInss;
            BaseCalculoIrrf = result.BaseCalculoIrrf;
            ValorRetCofins = result.ValorRetCofins;
            ValorRetPis = result.ValorRetPis;
            ValorRetIrrf = result.ValorRetIrrf;
            ValorRetInss = result.BaseCalculoInss;
            return null;
        }

        private bool CstGeraDifal(string cst)
            => cst.Equals("00") || cst.Equals("20") || cst.Equals("40") || cst.Equals("41") || cst.Equals("60") || cst.Equals("102") || cst.Equals("103") || cst.Equals("400") || cst.Equals("500");

    }
}
