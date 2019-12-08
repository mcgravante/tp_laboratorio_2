using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            FormClosing += cierraHilos;
            PaqueteDAO.sqlError += this.PaqueteDaoError;
        }

        /// <summary>
        /// Delegado del evento que se llama si hubo un error la 
        /// grabación de datos en la base desde PaqueteDAO
        /// </summary>
        /// <param name="message"></param>
        private void PaqueteDaoError(string message)
        {
            if (this.InvokeRequired)
            {
                DelegadoSqlException delegado = new DelegadoSqlException(PaqueteDaoError);
                this.Invoke(delegado, new object[] { message });
            }
            else
            {
                MessageBox.Show("No se guardó en base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado
        /// Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción
        /// Llamará al método ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string direccion = this.txtDireccion.Text;
            string trackingID = this.mtxtTrackingID.Text;
            if (direccion != null && trackingID != null)
            {
                Paquete paquete = new Paquete(direccion, trackingID);
                paquete.InformaEstado += this.paq_InformaEstado;
                try
                {
                    this.correo += paquete;
                }
                catch (TrackingIdRepetidoException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cargar dirección y trackingID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarEstados();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// evaluará que el atributo elemento no sea nulo
        /// Mostrará los datos de elemento en el rtbMostrar
        /// Utilizará el método de extensión para guardar los datos en un archivo llamado salida.txt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        public void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Clear();
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    this.rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al guardar los datos en archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// El método ActualizarEstados limpiará los 3 ListBox y luego recorrerá la lista de paquetes agregando 
        /// cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquete)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// llamará al método ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(Object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        ///  cerrar todos los hilos abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cierraHilos(object sender, EventArgs e)
        {
            this.correo.FinEntregas();
        }

    }
}
