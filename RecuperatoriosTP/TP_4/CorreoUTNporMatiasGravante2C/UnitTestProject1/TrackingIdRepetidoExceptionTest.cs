using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace UnitTestProject1
{
    [TestClass]
    public class TrackingIdRepetidoExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void CargoPaquetesConMismoTrackingID()
        {
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("MiCasa", "14285700");
            Paquete paq2 = new Paquete("TuCasa", "14285700");
            correo += paq1;
            correo += paq2;
            correo.FinEntregas();
        }
    }
}
