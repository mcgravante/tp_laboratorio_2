using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {

                this.dni = ValidarDni(this.nacionalidad, value);


            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// ToString retornará los datos de la Persona
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("NOMBRE COMPLETO: ");
            retorno.Append(this.Apellido + ", " + this.Nombre);
            retorno.AppendLine("");
            retorno.Append("NACIONALIDAD: ");
            retorno.Append(this.Nacionalidad);
            return retorno.ToString();
        }

        /// <summary>
        /// Validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException();
            }
            else if (nacionalidad.Equals(ENacionalidad.Extranjero) && dato < 90000000)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            else if (nacionalidad.Equals(ENacionalidad.Argentino) && dato > 89999999)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            return dato;
        }

        /// <summary>
        /// Verificar si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.)  
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!int.TryParse(dato, out int dni))
            {
                throw new DniInvalidoException("DNI inválido");
            }
            return ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. 
        /// Caso contrario, no se cargará
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {

            string val = "^[A-Za-zÀ-ú\x20\x2D\x27]";
            if (!Regex.IsMatch(dato, val))
                dato = "";
            return dato;
        }
        #endregion

        #region Enumeradores
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion
    }
}
