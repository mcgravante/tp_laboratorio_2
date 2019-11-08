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

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region Métodos
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));
        }

        override
        protected string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.Append("\r\n");
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();
        }

        override
        public string ToString()
        {
            return this.MostrarDatos();
        }

        override
        protected string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                retorno.Append("\r\n");
                retorno.Append(clase);
            }
            return retorno.ToString();
        }
        #endregion

        #region Operadores
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
