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
using MotorTributarioNet.Impostos.Csosns;
using MotorTributarioNet.Impostos.Csosns.Base;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Impostos.Csts.Base;
using MotorTributarioNet.Impostos.Tributacoes;
using MotorTributarioNet.Util;

namespace MotorTributarioNet.Impostos
{
    public class ResultadoTributacao
    {
        #region Impostos Privados  

        private TipoDesconto TipoDesconto { get; set; }
        private TipoPessoa TipoPessoa { get; set; }
        private TipoOperacao Operacao { get; set; }
        private Crt CrtEmpresa { get; set; }
        private CstBase Icms { get; set; }
        private CsosnBase CsosnBase { get; set; }
        private TributacaoPis Pis { get; set; }
        private TributacaoCofins Cofins { get; set; }
        private TributacaoIpi Ipi { get; set; }
        private TributacaoDifal Difal { get; set; }
        private TributacaoFcp TributacaoFcp { get; set; }
        private TributacaoIssqn Issqn { get; set; }
        private TributacaoIbpt Ibpt { get; set; }

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
        public decimal ValorBcFcp { get; private set; }
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
        public decimal ValorRetClss { get; private set; }

        public decimal ValorTributacaoFederal { get; private set; }
        public decimal ValorTributacaoFederalImportados { get; private set; }
        public decimal ValorTributacaoEstadual { get; private set; }
        public decimal ValorTributacaoMunicipal { get; private set; }
        public decimal ValorTotalTributos { get; private set; }
        #endregion

        private readonly ITributavelProduto _produto;
        public ResultadoTributacao(ITributavelProduto produto, Crt crtEmpresa, TipoOperacao operacao, TipoPessoa tipoPessoa, TipoDesconto tipoDesconto = TipoDesconto.Incondicional)
        {
            _produto = produto;
            CrtEmpresa = crtEmpresa;
            Operacao = operacao;
            TipoPessoa = tipoPessoa;
            TipoDesconto = tipoDesconto;
        }

        public ResultadoTributacao Calcular()
        { 
            if (_produto.IsServico)
            {
                var calcularRetencao = (CrtEmpresa != Crt.SimplesNacional && TipoPessoa != TipoPessoa.Fisica);
                CalcularIssqn(calcularRetencao);
            }
            else
            {
                CalcularIcms();
                CalcularDifal();
                CalcularFcp();
                CalcularIpi();
            }
            CalcularPis();
            CalcularCofins();
            CalcularIbpt();
            return this;
        }

        private void CalcularIcms()
        {
            if (CrtEmpresa == Crt.SimplesNacionalExecesso || CrtEmpresa == Crt.RegimeNormal)
            {
                switch (_produto.Cst)
                {
                    case Cst.Cst00:
                        Icms = new Cst00();
                        Icms.Calcula(_produto);
                        ValorBcIcms = ((Cst00)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst00)Icms).PercentualIcms;
                        ValorIcms = ((Cst00)Icms).ValorIcms;
                        break;
                    case Cst.Cst10:
                        Icms = new Cst10();
                        Icms.Calcula(_produto);
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
                        Icms.Calcula(_produto);
                        ValorBcIcms = ((Cst20)Icms).ValorBcIcms;
                        PercentualIcms = ((Cst20)Icms).PercentualIcms;
                        ValorIcms = ((Cst20)Icms).ValorIcms;
                        PercentualReducao = ((Cst20)Icms).PercentualReducao;
                        break;
                    case Cst.Cst30:
                        Icms = new Cst30();
                        Icms.Calcula(_produto);
                        PercentualMva = ((Cst30)Icms).PercentualMva;
                        PercentualReducaoSt = ((Cst30)Icms).PercentualReducaoSt;
                        ValorBcIcmsSt = ((Cst30)Icms).ValorBcIcmsSt;
                        PercentualIcmsSt = ((Cst30)Icms).PercentualIcmsSt;
                        ValorIcmsSt = ((Cst30)Icms).ValorIcmsSt;
                        break;
                    case Cst.Cst40:
                        Icms = new Cst40();
                        Icms.Calcula(_produto);
                        ValorIcmsDesonerado = ((Cst40)Icms).ValorIcmsDesonerado;
                        break;
                    case Cst.Cst41:
                        Icms = new Cst41();
                        Icms.Calcula(_produto);
                        break;
                    case Cst.Cst50:
                        Icms = new Cst50();
                        Icms.Calcula(_produto);
                        break;
                    case Cst.Cst51:
                        Icms = new Cst51();
                        Icms.Calcula(_produto);
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
                        Icms.Calcula(_produto);
                        PercentualBcStRetido = ((Cst60)Icms).PercentualBcStRetido;
                        ValorBcStRetido = ((Cst60)Icms).ValorBcStRetido;
                        break;
                    case Cst.Cst70:
                        Icms = new Cst70();
                        Icms.Calcula(_produto);
                        PercentualReducao = ((Cst70)Icms).PercentualReducao;
                        break;
                    case Cst.Cst90:
                        Icms = new Cst90();
                        Icms.Calcula(_produto);
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
                switch (_produto.Csosn)
                {
                    //101 Tributada pelo Simples Nacional com permissão de crédito
                    case Csosn.Csosn101:
                        CsosnBase = new Csosn101();
                        CsosnBase.Calcula(_produto);
                        ValorCredito = ((Csosn101)CsosnBase).ValorCredito;
                        PercentualCredito = ((Csosn101)CsosnBase).PercentualCredito;
                        break;

                    case Csosn.Csosn102:
                        //102 Tributada pelo Simples Nacional sem permissão de crédito
                        //nao tem calculo
                        break;

                    case Csosn.Csosn103:
                        //103 Isenção do ICMS no Simples Nacional para faixa de receita bruta
                        //nao tem calculo
                        break;

                    //201 Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por substituição tributária    
                    case Csosn.Csosn201:
                        CsosnBase = new Csosn201();
                        CsosnBase.Calcula(_produto);
                        ValorCredito = ((Csosn201)CsosnBase).ValorCredito;
                        PercentualCredito = ((Csosn201)CsosnBase).PercentualCredito;

                        switch (((Csosn201)CsosnBase).ModalidadeDeterminacaoBcIcmsSt)
                        {
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNegativa:
                                //lista Negativa(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaPositiva:
                                //Lista Positiva(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNeutra:
                                //Lista Neutra(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado:
                                PercentualMva = ((Csosn201)CsosnBase).PercentualMva;
                                PercentualIcmsSt = ((Csosn201)CsosnBase).PercentualIcmsSt;
                                PercentualReducaoSt = ((Csosn201)CsosnBase).PercentualReducaoSt;
                                ValorIcmsSt = ((Csosn201)CsosnBase).ValorIcmsSt;
                                ValorBcIcmsSt = ((Csosn201)CsosnBase).ValorBcIcmsSt;

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.Pauta:

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.PrecoTabeladoOuMaximoSugerido:
                                //Preço Tabelado ou Máximo Sugerido
                                break;
                        }
                        break;
                    //202 Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por substituição tributária    

                    case Csosn.Csosn202:
                        CsosnBase = new Csosn202();
                        CsosnBase.Calcula(_produto);

                        switch (((Csosn202)CsosnBase).ModalidadeDeterminacaoBcIcmsSt)
                        {
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNegativa:
                                //lista Negativa(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaPositiva:
                                //Lista Positiva(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNeutra:
                                //Lista Neutra(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado:
                                //Margem valor Agregado(%)
                                PercentualMva = ((Csosn202)CsosnBase).PercentualMvaSt;
                                PercentualIcmsSt = ((Csosn202)CsosnBase).PercentualIcmsSt;
                                PercentualReducaoSt = ((Csosn202)CsosnBase).PercentualReducaoSt;
                                ValorIcmsSt = ((Csosn202)CsosnBase).ValorIcmsSt;
                                ValorBcIcmsSt = ((Csosn202)CsosnBase).ValorBcIcmsSt;

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.Pauta:

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.PrecoTabeladoOuMaximoSugerido:
                                //Preço Tabelado ou Máximo Sugerido
                                break;
                        }
                        break;

                    case Csosn.Csosn203:
                        CsosnBase = new Csosn203();
                        CsosnBase.Calcula(_produto);

                        switch (((Csosn203)CsosnBase).ModalidadeDeterminacaoBcIcmsSt)
                        {
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNegativa:
                                //lista Negativa(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaPositiva:
                                //Lista Positiva(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.ListaNeutra:
                                //Lista Neutra(valor)
                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado:
                                //Margem valor Agregado(%)
                                PercentualMva = ((Csosn203)CsosnBase).PercentualMvaSt;
                                PercentualIcmsSt = ((Csosn203)CsosnBase).PercentualIcmsSt;
                                PercentualReducaoSt = ((Csosn203)CsosnBase).PercentualReducaoSt;
                                ValorIcmsSt = ((Csosn203)CsosnBase).ValorIcmsSt;
                                ValorBcIcmsSt = ((Csosn203)CsosnBase).ValorBcIcmsSt;

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.Pauta:

                                break;
                            case ModalidadeDeterminacaoBcIcmsSt.PrecoTabeladoOuMaximoSugerido:
                                //Preço Tabelado ou Máximo Sugerido
                                break;
                        }
                        break;

                    case Csosn.Csosn300:
                        //300 Imune - Classificam-se neste código as operações praticadas por optantes pelo Simples Nacional contempladas com imunidade do ICMS
                        //nao tem calculo
                        break;

                    case Csosn.Csosn400:
                        //400 Não tributada pelo Simples Nacional - Classificam-se neste código as operações praticadas por optantes pelo Simples Nacional não sujeitas à tributação pelo ICMS dentro do Simples Nacional
                        //nao tem calculo
                        break;

                    case Csosn.Csosn500:
                        //500 ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação - Classificam-se neste código as operações sujeitas exclusivamente ao regime de substituição tributária na condição de substituído tributário ou no caso de antecipações
                        //nao tem calculo
                        break;

                    case Csosn.Csosn900:
                        CsosnBase = new Csosn900();
                        CsosnBase.Calcula(_produto);
                        PercentualCredito = ((Csosn900)CsosnBase).PercentualCredito;
                        ValorCredito = ((Csosn900)CsosnBase).ValorCredito;
                        ValorIcms = ((Csosn900)CsosnBase).ValorIcms;
                        ValorBcIcms = ((Csosn900)CsosnBase).ValorBcIcms;
                        PercentualMva = ((Csosn900)CsosnBase).PercentualMva;
                        PercentualIcmsSt = ((Csosn900)CsosnBase).PercentualIcmsSt;
                        PercentualReducaoSt = ((Csosn900)CsosnBase).PercentualReducaoSt;
                        ValorIcmsSt = ((Csosn900)CsosnBase).ValorIcmsSt;
                        ValorBcIcmsSt = ((Csosn900)CsosnBase).ValorBcIcmsSt;
                        break;

                    default:
                        break;
                }
            }
        }


        private TributacaoIpi CalcularIpi()
        {
            Ipi = new TributacaoIpi(_produto, TipoDesconto);
            ValorIpi = decimal.Zero;
            ValorBcIpi = decimal.Zero;

            if (_produto.CstIpi == CstIpi.Cst00
                || _produto.CstIpi == CstIpi.Cst49
                || _produto.CstIpi == CstIpi.Cst50
                || _produto.CstIpi == CstIpi.Cst99)
            {
                var result = Ipi.Calcula();
                ValorIpi = result.Valor;
                ValorBcIpi = result.BaseCalculo;
            }
            return Ipi;
        }

        private TributacaoPis CalcularPis()
        {
            Pis = new TributacaoPis(_produto, TipoDesconto);
            ValorPis = decimal.Zero;
            ValorBcPis = decimal.Zero;

            if (_produto.CstPisCofins == CstPisCofins.Cst01
               || _produto.CstPisCofins == CstPisCofins.Cst02)
            {
                var result = Pis.Calcula();
                ValorPis = result.Valor;
                ValorBcPis = result.BaseCalculo;
            }
            return Pis;
        }

        private TributacaoCofins CalcularCofins()
        {
            Cofins = new TributacaoCofins(_produto, TipoDesconto);
            ValorCofins = decimal.Zero;
            ValorBcCofins = decimal.Zero;

            if (_produto.CstPisCofins == CstPisCofins.Cst01
                || _produto.CstPisCofins == CstPisCofins.Cst02)
            {
                var result = Cofins.Calcula();
                ValorCofins = result.Valor;
                ValorBcCofins = result.BaseCalculo;

            }
            return Cofins;
        }

        private TributacaoIssqn CalcularIssqn(bool calcularRetencao)
        {
            Issqn = new TributacaoIssqn(_produto, TipoDesconto);
            var result = Issqn.Calcula(calcularRetencao);
            BaseCalculoInss = result.BaseCalculoInss;
            BaseCalculoIrrf = result.BaseCalculoIrrf;
            ValorRetCofins = result.ValorRetCofins;
            ValorRetPis = result.ValorRetPis;
            ValorRetIrrf = result.ValorRetIrrf;
            ValorRetInss = result.ValorRetInss;
            ValorRetClss = result.ValorRetCsll;
            ValorIss = result.Valor;
            return Issqn;
        }

        private TributacaoFcp CalcularFcp()
        {
            TributacaoFcp = new TributacaoFcp(_produto, TipoDesconto);
            Fcp = decimal.Zero;
            ValorBcFcp = decimal.Zero;

            var result = TributacaoFcp.Calcula();

            Fcp = result.Valor;
            ValorBcFcp = result.BaseCalculo;

            return TributacaoFcp;
        }

        private TributacaoDifal CalcularDifal()
        {
            var cstCson = (Crt.RegimeNormal == CrtEmpresa ? _produto.Cst.GetValue<int>() : _produto.Csosn.GetValue<int>());
            Difal = new TributacaoDifal(_produto, TipoDesconto);
            ValorBcDifal = decimal.Zero;
            ValorDifal = decimal.Zero;
            ValorIcmsOrigem = decimal.Zero;
            ValorIcmsDestino = decimal.Zero;

            if (Operacao == TipoOperacao.OperacaoInterestadual
                   && CstGeraDifal(cstCson)
                   && _produto.PercentualDifalInterna != 0
                   && _produto.PercentualDifalInterestadual != 0)
            {
                var result = Difal.Calcula();
                ValorBcDifal = result.BaseCalculo;
                ValorDifal = result.Difal;
                ValorIcmsOrigem = result.ValorIcmsOrigem;
                ValorIcmsDestino = result.ValorIcmsDestino;
            }
            return Difal;
        }

        private TributacaoIbpt CalcularIbpt()
        {
            Ibpt = new TributacaoIbpt(_produto,_produto);
            var result = Ibpt.Calcula();
            ValorTributacaoEstadual = result.TributacaoEstadual;
            ValorTributacaoFederal = result.TributacaoFederal;
            ValorTributacaoFederalImportados = result.TributacaoFederalImportados;
            ValorTributacaoMunicipal = result.TributacaoMunicipal;
            ValorTotalTributos = result.ValorTotalTributos;
            return Ibpt;
        }

        private bool CstGeraDifal(int cst)
            => cst == 0 || cst == 20 || cst == 40 || cst == 41 || cst == 60 || cst ==102 || cst == 103 || cst == 400 || cst == 500 ;

      
    }
}
