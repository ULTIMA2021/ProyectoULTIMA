using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;
using MySql.Data.MySqlClient;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestModelo
    {
        [TestMethod]
        public void TestConexion()
        {

            try
            {
                Modelo m = new Modelo(2);
                Assert.AreEqual("Open", m.conexion.State.ToString());
            }
            catch
            {
                Assert.IsTrue(false); 
            }
        }
    }
}
