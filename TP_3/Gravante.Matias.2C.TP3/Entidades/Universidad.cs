using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public class Universidad
    {
        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructotres
        public Universidad()
        {
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            return true;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            return true;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static bool operator ==(Universidad u, EClases clase)
        {
            return true;
        }

        public static bool operator !=(Universidad u, EClases clase)
        {
            return !(u == clase);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            return u;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            return g;
        }
        #endregion

        #region Métodos
        public static bool Guardar(Universidad uni)
        {
            return true;
        }

        public static Universidad Leer()
        {
            return new Universidad();
        }

        private string MostrarDatos(Universidad uni)
        {
            return "a completar";
        }

        override
        public string ToString()
        {
            return "a completar";
        }
        #endregion

        #region Enumeradores
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion
    }
}
