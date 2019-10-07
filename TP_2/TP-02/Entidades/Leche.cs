using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region "Enumerados"
        public enum ETipo { Entera, Descremada }
        #endregion

        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this.tipo = ETipo.Entera;
        }
        //Da lo mismo si reutilizo código en este caso, porque usando el constructor por defecto asigno
        //un valor al tipo de leche que luego reasigno. Pero me gusta reutilizar código igual.
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region "Metodos"
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
