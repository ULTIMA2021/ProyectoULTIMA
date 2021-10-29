using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestOrientacionModelo
    {
        [TestMethod]
        public void TestAltaOrientacion()
        {
            try
            {
                OrientacionModelo orientacion = new OrientacionModelo(2);

                orientacion.nombreOrientacion = "test";
                orientacion.crearMateriaNueva();

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestBajaOrientacion()
        {
            try
            {
                OrientacionModelo orientacion = new OrientacionModelo(2);
                orientacion.borrarOrientacion("4");
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestActualizarOrientacion()
        {
            try
            {
                OrientacionModelo orientacion = new OrientacionModelo(2);
                orientacion.actualizarNombreDeOrientacion("desarollo y soporte", "1");

                Assert.IsTrue(true);

            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestGetOrientacion()
        {
            try
            {
                if (new OrientacionModelo(2).getOrientacion("desarrollo y soporte") == "1")
                    Assert.IsTrue(true);
                else{ };
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
