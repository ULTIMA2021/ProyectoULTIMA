using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestSalaModelo
    {
        [TestMethod]
        public void TestCrearSala()
        {
            try
            {


                SalaModelo sala = new SalaModelo();

                    sala.idGrupo = int.Parse("1");
                sala.idMateria = int.Parse("1");
                sala.docenteCi = int.Parse("77777777");
                sala.anfitrion = int.Parse("1");
                sala.resumen = "resumen";
                sala.creacion = sala.creacion;
                sala.isDone = false;
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }
    }
}
