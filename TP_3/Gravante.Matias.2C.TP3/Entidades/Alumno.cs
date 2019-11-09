using System.Text;
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
        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        override
        protected string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine("");
            retorno.Append("ESTADO DE CUENTA: ");
            retorno.Append(this.estadoCuenta);
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();
        }

        /// <summary>
        /// e retornará la cadena "TOMA CLASE DE " 
        /// junto al nombre de la clase que toma. 
        /// </summary>
        /// <returns></returns>
        override
        protected string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("");
            retorno.Append("TOMA CLASES DE: ");
            retorno.Append(this.claseQueToma);
            return retorno.ToString();
        }

        /// <summary>
        ///  hará públicos los datos del Alumno. 
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase 
        /// y su estado de cuenta no es Deudor.
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma.Equals(clase)
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
