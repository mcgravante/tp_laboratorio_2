using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Métodos
        public void MockCicloDeVida()
        { }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return "a completar";
        }

        public string ToString()
        {
            return "a completar";
        }
        #endregion

        #region Operadores
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Eventos

        public event DelegadoEstado InformaEstado;
        #endregion

        #region Tipos anidados
        public delegate void DelegadoEstado();

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #endregion
    }
}
