using System;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns.Base
{
    public abstract class CsosnBase
    {
        public OrigemMercadoria OrigemMercadoria { get; }
        public Csosn Csosn { get; protected set; }

        public CsosnBase(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional)
        {
            OrigemMercadoria = origemMercadoria;
        }

        public virtual void Calcula(ITributavel tributavel)
        {
            throw new ArgumentException("Não existe calculo!");
        }
    }
}