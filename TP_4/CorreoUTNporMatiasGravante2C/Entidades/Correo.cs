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
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Métodos
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item != null && item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            Correo correo = (Correo)elementos;
            string ret = "";
            foreach (Paquete item in correo.paquetes)
            {
                ret += String.Format("\n{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }
            return ret;
        }
        #endregion

        #region Operadores
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException($"El paquete {p.TrackingID} ya se encuentra cargado");
                }
            }
            c.paquetes.Add(p);
            Thread t1 = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t1);
            try
            {
                t1.Start();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo iniciar el thread ", e);
            }
            return c;
        }
        #endregion
    }
}

