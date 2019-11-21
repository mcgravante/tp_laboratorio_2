using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquete
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores
        public Correo()
        { }
        #endregion

        #region Métodos
        public void FinEntregas()
        { }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return "a completar";
        }
        #endregion

        #region Operadores
        public static Correo operator +(Correo c, Paquete p)
        {
            return new Correo();
        }
        #endregion
    }
}

