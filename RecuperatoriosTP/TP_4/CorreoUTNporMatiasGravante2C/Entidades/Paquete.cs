using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// hará que el paquete cambie de estado
        /// Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado.Invoke(this, new EventArgs());
            }
            while (this.estado != EEstado.Entregado);
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra información del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        ///  retornará la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
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
        public delegate void DelegadoEstado(Object sender, EventArgs e);

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #endregion
    }
}
