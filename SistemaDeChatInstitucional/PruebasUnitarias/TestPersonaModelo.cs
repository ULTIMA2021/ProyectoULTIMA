using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;
using MySql.Data.MySqlClient;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestPersonaModelo
    {
        [TestMethod]
        public void TestAltaPersona()
        {
            try
            {
                PersonaModelo p = new PersonaModelo();
                p.Cedula = "11111122";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.GuardarPersona();


                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }
            
        }
    }
}
