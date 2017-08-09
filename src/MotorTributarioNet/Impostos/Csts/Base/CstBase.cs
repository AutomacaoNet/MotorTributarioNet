using MotorTributarioNet.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorTributarioNet.Impostos.Csts.Base
{
    public abstract class CstBase
    {
        public OrigemMercadoria OrigemMercadoria { get; }
        public Cst Cst { get; protected set; }

        public CstBase(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional)
        {
            OrigemMercadoria = origemMercadoria;
        }

        public virtual void Calcula(ITributavel tributavel)
        {
            throw new ArgumentException("Não existe calculo!");
        }
    }
}
