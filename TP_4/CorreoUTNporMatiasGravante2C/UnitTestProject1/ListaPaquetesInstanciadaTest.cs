using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class ListaPaquetesInstanciadaTest
    {
        [TestMethod]
        public void InstanciarLista()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquete);
        }
    }
}
