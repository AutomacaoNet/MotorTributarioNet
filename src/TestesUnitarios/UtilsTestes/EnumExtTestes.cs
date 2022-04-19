using MotorTributarioNet.Util;
using Xunit;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace TestCalculosTributarios.UtilsTestes
{
    public class EnumExtTestes
    {
        [Fact]
        public void ObterAtributo_Obter_Sucesso()
        {
            // arrange
            var cst00 = MotorTributarioNet.Flags.Cst.Cst00;

            // action
            var atributo = cst00.ObterAtributo<DescriptionAttribute>();

            // assert
            Assert.Equal(typeof(DescriptionAttribute), atributo.GetType());
        }

        [Fact]
        public void ObterDescricao_Obter_Sucesso()
        {
            // arrange
            var cst00 = MotorTributarioNet.Flags.Cst.Cst00;

            // action
            var descricao = cst00.Descricao();

            // assert
            Assert.Equal("00 - Tributada integralmente.", descricao);
        }

        [Fact]
        public void ObterDescricao_RetornarNomeEnumUtilizado_IndexOutOfRangeException()
        {
            // arrange
            var um = EnumTeste.Um;

            // action // assert
            Assert.Throws<System.IndexOutOfRangeException>(um.Descricao);
        }

        [Fact]
        public void GetValue_Null_Sucesso()
        {
            // arrange
            var um = EnumTeste.Um;

            // action 
            var resultado = um.GetValue<TesteConversaoEnum>();

            // assert
            Assert.Null(resultado);
        }
    }

    public enum EnumTeste
    {
        Um
    }

    public class TesteConversaoEnum
    {

    }
}