using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region Campos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        public Alumno() : base()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        override
        protected string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.Append("\r\n");
            retorno.Append("ESTADO DE CUENTA: ");
            retorno.Append(this.estadoCuenta);
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();
        }

        override
        protected string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\r\nTOMA CLASES DE: ");
            retorno.Append(this.claseQueToma);
            return retorno.ToString();
        }

        override
        public string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.ParticiparEnClase().Equals(clase)
                && !a.estadoCuenta.Equals(EEstadoCuenta.Deudor))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion

        #region Enumeradores
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

    }
}
