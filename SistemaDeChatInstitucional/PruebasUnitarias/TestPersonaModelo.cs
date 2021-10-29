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
        public void TestAltaModPersona()
        {
            try
            {
                PersonaModelo p = new PersonaModelo(2);
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


        [TestMethod]
        public void TestModPersona()
        {
            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.actualizarPersona("55555555", "NUEVONOMBRE", "NUEVOAPE", "CLAVE", null);

                if (p.obtenerPersona("55555555").Nombre == "NUEVONOMBRE")
                    Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }


        [TestMethod]
        public void TestBajaPersona()
        {
            try
            {
                new PersonaModelo(2).bajaPersona("00000000");
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "00000000";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.GuardarPersona();

                new PersonaModelo(2).bajaPersona("00000000");

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestAltaAlumno()
        {
            PersonaModelo p = new PersonaModelo(2);
            p.bajaPersona("00000000");
            p.Cedula = "00000000";
            p.Nombre = "Juan";
            p.Apellido = "Aguiar";
            p.Clave = "11111122";
            p.foto = null;
            p.GuardarPersona();
            try
            {
                p.Apodo = "apodo";
                p.guardarAlumno();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }


        [TestMethod]
        public void TestAltaAlumnoTemp()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.bajaAlumnoTemp("11111110");
                p.Cedula = "11111110";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.Apodo = "Juancito";
                p.Grupos = null;
                p.guardarAlumno("1-3-5");

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestBajaAlumnoTemp()
        {
            PersonaModelo p = new PersonaModelo(2);
            try
            {
                p.Cedula = "11111117";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.Apodo = "Juancito";
                p.Grupos = null;
                p.guardarAlumno("1-3-5");
            }
            catch
            {
                try
                {
                    p.bajaAlumnoTemp("11111117");
                    Assert.IsTrue(true);
                }
                catch
                {
                    Assert.IsTrue(false);
                }

            }
        }

        [TestMethod]
        public void TestAltaDocente()
        {
            PersonaModelo p = new PersonaModelo(2);
            p.bajaPersona("00000000");
            p.Cedula = "00000000";
            p.Nombre = "Juan";
            p.Apellido = "Aguiar";
            p.Clave = "00000000";
            p.foto = null;
            p.GuardarPersona();
            try
            {
                p.guardarDocente();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void TestAltaAdmin()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "88888888";
                p.guardarAdmin();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }










        [TestMethod]
        public void TestObtenerPersona()
        {
            try
            {
                string cedula = "11111111";
                PersonaModelo p = new PersonaModelo(2);
                p = p.obtenerPersona(cedula);

                Assert.IsNotNull(p.Cedula);
                Assert.IsNotNull(p.Nombre);
                Assert.IsNotNull(p.Apellido);


            }
            catch
            {
                Assert.IsTrue(false);

            }

        }


        [TestMethod]
        public void TestObtenerAlumnoTemp()
        {
            PersonaModelo p = new PersonaModelo(2);
            p.Cedula = "11111190";
            p.Nombre = "Juan";
            p.Apellido = "Aguiar";
            p.Clave = "11111122";
            p.foto = null;
            p.Apodo = "Juancito";
            p.Grupos = null;
            p.guardarAlumno("1-3-5");

            try
            {
                Assert.IsNotNull(p.obtenerAlumnoTemp()[0].Cedula);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        //[TestMethod]
        //public void Test()
        //{

        //    try
        //    {
        //        PersonaModelo p = new PersonaModelo();
        //        p.obtenerAlumnoTemp();

        //        Assert.IsNotNull(p.Cedula);
        //        Assert.IsNotNull(p.Nombre);
        //        Assert.IsNotNull(p.Apellido);
        //        Assert.IsNotNull(p.Apodo);
        //        Assert.IsNotNull(p.Grupos);


        //    }
        //    catch
        //    {
        //        Assert.IsTrue(false);

        //    }

        //}
    }
}
