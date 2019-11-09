using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        private Profesor() : base()
        { }

        /// <summary>
        ///  se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor mediante el método randomClases. 
        ///  Las dos clases pueden o no ser la misma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Asigna clase aleatoria a profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));
        }

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        override
        protected string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();
        }

        /// <summary>
        ///  hará públicos los datos del Profesor
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        ///  retornará la cadena "CLASES DEL DÍA" 
        ///  junto al nombre de la clases que da. 
        /// </summary>
        /// <returns></returns>
        override
        protected string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                retorno.AppendLine(clase.ToString());
            }
            return retorno.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
