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

using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;
using static System.Collections.Specialized.BitVector32;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIcmsDesonerado
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;
        private readonly TipoCalculoIcmsDesonerado? _tipoCalculoIcmsDesonerado;

        public TributacaoIcmsDesonerado(ITributavel tributavel, TipoDesconto tipoDesconto, TipoCalculoIcmsDesonerado? tipoCalculoIcmsDesonerado)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
            _tipoCalculoIcmsDesonerado = tipoCalculoIcmsDesonerado;
        }

        public IResultadoCalculoIcmsDesonerado Calcula()
        {
            return CalculaIcmsDesonerado();
        }

        private IResultadoCalculoIcmsDesonerado CalculaIcmsDesonerado()
        {
            decimal subtotalProduto = _tributavel.ValorProduto * _tributavel.QuantidadeProduto;
            decimal baseCalculo = _calculaBaseCalculoIcms.CalculaBaseCalculo();

            var valorIcmsDesonerado = CalculaIcmsDesonerado(_tipoCalculoIcmsDesonerado == TipoCalculoIcmsDesonerado.BaseSimples ? baseCalculo : subtotalProduto, _tipoCalculoIcmsDesonerado);

            return new ResultadoCalculoIcmsDesonerado(subtotalProduto, valorIcmsDesonerado);
        }

        private decimal CalculaIcmsDesonerado(decimal valorBase, TipoCalculoIcmsDesonerado? tipoCalculoIcmsDesonerado)
        {
            decimal aliquota = _tributavel.PercentualIcms / 100;

            if (tipoCalculoIcmsDesonerado == TipoCalculoIcmsDesonerado.BaseSimples)
            {
                return valorBase * aliquota;
            }
            else if (tipoCalculoIcmsDesonerado == TipoCalculoIcmsDesonerado.BasePorDentro)
            {
                if (_tributavel.Cst == Cst.Cst20 || _tributavel.Cst == Cst.Cst70) //base por dentro 20 ou 70: ICMS Desonerado = Preço na Nota Fiscal * (1 - (Alíquota * (1 - Percentual de redução da BC))) / (1 - Alíquota) - Preço na Nota Fiscal
                {
                    return ((valorBase * (1 - (aliquota * (1 - (_tributavel.PercentualReducao / 100)))) / (1 - aliquota)) - valorBase); ;
                }
                else if (_tributavel.Cst == Cst.Cst30 || _tributavel.Cst == Cst.Cst40) //base por dentro 30 ou 40: ICMS Desonerado = (Preço na Nota Fiscal / (1 - Alíquota)) * Alíquota
                {
                    return (valorBase / (1 - aliquota)) * aliquota;
                }
            }
            return 0m;
        }
    }
}