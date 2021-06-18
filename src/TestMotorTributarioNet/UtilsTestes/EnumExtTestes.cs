using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Util;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace TestCalculosTributarios.UtilsTestes
{
    [TestClass]
    public class EnumExtTestes
    {
        [TestMethod]
        public void ObterAtributo_Obter_Sucesso()
        {
            // arrange
            var cst00 = MotorTributarioNet.Flags.Cst.Cst00;

            // action
            var atributo = cst00.ObterAtributo<DescriptionAttribute>();

            // assert
            Assert.AreEqual(typeof(DescriptionAttribute), atributo.GetType());
        }

        [TestMethod]
        public void ObterDescricao_Obter_Sucesso()
        {
            // arrange
            var cst00 = MotorTributarioNet.Flags.Cst.Cst00;

            // action
            var descricao = cst00.Descricao();

            // assert
            Assert.AreEqual("00 - Tributada integralmente.", descricao);
        }

        [TestMethod]
        public void ObterDescricao_RetornarNomeEnumUtilizado_IndexOutOfRangeException()
        {
            // arrange
            var um = EnumTeste.Um;

            // action // assert
            Assert.ThrowsException<System.IndexOutOfRangeException>(um.Descricao);
        }

        [TestMethod]
        public void GetValue_Null_Sucesso()
        {
            // arrange
            var um = EnumTeste.Um;

            // action 
            var resultado = um.GetValue<TesteConversaoEnum>();

            // assert
            Assert.AreEqual(null, resultado);
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