using MotorTributarioNet.Impostos.Csts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst50 : CstBase
    {
        public Cst50(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst50;
        }
    }
}
