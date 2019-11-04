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
        private static Queue<EClases> clasesDelDia;
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
            clasesDelDia = new Queue<EClases>;
        }
        #endregion

        #region Métodos
        private void _randomClases()
        { }

        override
        protected string MostrarDatos()
        {
            return "a completar";
        }

        override
        public string ToString()
        {
            return "a completar";
        }

        override
        protected string ParticiparEnClase()
        {
            return "a completar";
        }
        #endregion

        #region Operadores
        public static bool operator ==(Profesor i, EClases clase)
        {
            return true;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
