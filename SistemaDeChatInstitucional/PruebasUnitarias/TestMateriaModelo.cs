using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestMateriaModelo
    {
        [TestMethod]
        public void TestAltaMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.nombreMateria = "Biologia";
                materia.crearMateriaNueva();
                Assert.IsTrue(true);

            }
            catch 
            {

                Assert.IsTrue(false);
            }
            
        }

        [TestMethod]
        public void TestModEstadoMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.actualizarEstadoDeMateria(true, "1");
                Assert.IsTrue(true);
                MateriaModelo mate = new MateriaModelo(2);
                mate.actualizarEstadoDeMateria(false, "1");
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestModMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.actualizarNombreDeMateria("test", "1");
                Assert.IsTrue(true);

                MateriaModelo mate = new MateriaModelo(2);
                mate.actualizarNombreDeMateria("mat1", "1");
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestBajaMateria()
        {
            try
            {
                new MateriaModelo(2).borrarMateria("15");
                List<MateriaModelo> materias = new MateriaModelo(2).getMateria();
                bool valid = true;
                foreach (MateriaModelo materia in materias)
                    if (materia.idMateria == 15)
                        valid = false;

                Assert.IsTrue(valid);

            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestGetMateria()
        {
            try
            {
                string nombreMateria = "mat1";
                MateriaModelo materia = new MateriaModelo(2);
                materia.getMateria(nombreMateria);
                Assert.IsNotNull(materia.idMateria);

            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCountSalaMateria()
        {
            try
            {

                MateriaModelo materia = new MateriaModelo(2);
                materia.idMateria = 1;
                materia.countSalaPorMateria();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestAsignarMateriaAGrupo()
        {
            try
            {
                new GrupoModelo(2).cargarMateriasAGrupo("1","5");
                List <MateriaModelo> grupoMaterias = new MateriaModelo(2).getGrupoTieneMateria("5");
                bool valid = false;
                foreach (MateriaModelo grupoMateria in grupoMaterias)
                    if (grupoMateria.idMateria == 1)
                        valid = true;
                Assert.IsTrue(valid);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
