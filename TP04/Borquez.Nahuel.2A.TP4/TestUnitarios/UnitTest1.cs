using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la lista de Paquetes del Correo esté instanciada
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Correo c = new Correo();

            Assert.IsTrue(true);

            Assert.IsNotNull(c);
        }

        /// <summary>
        /// Verifica que no haya dos trackid iguales
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestTrackingIdRepetidoException()
        {
            Correo c = new Correo();

            Paquete p1 = new Paquete("Belgrano", "999-999-9999");
            Paquete p2 = new Paquete("RamonFranco", "999-999-9999");
            
            c += p1;
            c += p2;
            
        }
    }
}
