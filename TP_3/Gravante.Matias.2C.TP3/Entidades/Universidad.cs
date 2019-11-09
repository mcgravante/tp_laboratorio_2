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

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexado
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  retornará el primer Profesor capaz de dar esa clase. 
        ///  Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  retornará el primer Profesor que no pueda dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, 
        /// validando que no estén previamente cargados
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, 
        /// validando que no estén previamente cargados
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada 
        /// indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// serializará los datos del Universidad en un XML, 
        /// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  retornará un Universidad con todos los datos previamente serializados
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Hará públicos los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
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
