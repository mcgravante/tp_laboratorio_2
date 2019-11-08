using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public class Jornada
    {
        #region Campos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Métodos
        public static bool Guardar(Jornada jornada)
        {
            return true;
        }

        public static string Leer()
        {
            return "a completar";
        }

        override
        public string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA: ");
            retorno.Append("\r\n");
            retorno.Append("CLASE DE ");
            retorno.Append(this.clase);
            retorno.Append("POR ");
            retorno.Append(this.instructor.ToString());
            retorno.Append("\r\n");
            retorno.Append("ALUMNOS: ");
            retorno.Append("\r\n");
            foreach (Alumno alumno in this.Alumnos)
            {
                retorno.Append("\r\n");
                retorno.Append(alumno);
            }
            return retorno.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!j.Alumnos.Contains(a))
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion

    }
}
