using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using EntidadesAbstractas;

namespace TestsUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void CheckDniInvalidoException()
        {
            Alumno alumno = new Alumno(1, "Pepe", "Sapo", "100000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void CheckSinProfesorException()
        {
            Universidad u = new Universidad();
            Profesor p = (u == Universidad.EClases.SPD);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void CheckAlumnoRepetidoException()
        {
            Alumno a = new Alumno(1, "Pepe", "Sapo", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno a2 = new Alumno(2, "René", "Rana", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Universidad u = new Universidad();
            u += a;
            u += a2;
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void CheckNacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(1, "Pepe", "Sapo", "33333333", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }

        [TestMethod]
        public void CheckJornadaFieldNotNull()
        {
            Profesor p = new Profesor(1, "Frog", "Froggy", "22222222", Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);
            Assert.IsNotNull(j.Alumnos);
        }

        [TestMethod]
        public void CheckUniversidadFieldsNotNull()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Alumnos);
            Assert.IsNotNull(u.Instructores);
            Assert.IsNotNull(u.Jornadas);
        }

        [TestMethod]
        public void CheckDNIStringToInt()
        {
            Alumno p = new Alumno(1, "Pepe", "Sapo", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            int expected = 33333333;
            Assert.AreEqual(p.DNI, expected);
        }
    }
}
