using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Constructores
        public Universitario() : base()
        { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        override
        public bool Equals(Object obj)
        {
            if (obj is Universitario && this is Universitario)
            {
                return true;
            }
            return false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.Append("\r\n");
            retorno.Append("LEGAJO NÚMERO: ");
            retorno.Append(this.legajo);
            return retorno.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) &&
                (pg1.legajo.Equals(pg2.legajo) ||
                (pg1.DNI.Equals(pg2.DNI))))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
