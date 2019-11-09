using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

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
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
                if (alumno == a)
                {
                    return true;
                }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
                if (profesor == i)
                {
                    return true;
                }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        #endregion

        #region Métodos
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            if (!(uni is null))
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                retorno = xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
            }
            return retorno;
        }
        public static Universidad Leer()
        {
            Universidad retorno = null;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out retorno);
            return retorno;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA: ");
            foreach (Jornada jornada in uni.Jornadas)
            {
                retorno.Append(jornada.ToString());
            }
            return retorno.ToString();
        }

        override
        public string ToString()
        {
            return MostrarDatos(this);
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
