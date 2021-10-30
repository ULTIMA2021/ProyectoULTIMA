using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestConsultaPrivadaModelo
    {
        [TestMethod]
        public void TestCrearConsultaPrivada()
        {
            try
            {
                new ConsultaPrivadaModelo(2).crearConsultaPrivada(int.Parse("18"),"77777777","11111111","test","pendiente",DateTime.Now);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestObtenerConsulta()
        {
            try
            {
                List <ConsultaPrivadaModelo> consultas = new  ConsultaPrivadaModelo(2).getConsultas("11111111");
                if (consultas[0].idConsultaPrivada > 0)
                    Assert.IsTrue(true);
                else
                    Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}