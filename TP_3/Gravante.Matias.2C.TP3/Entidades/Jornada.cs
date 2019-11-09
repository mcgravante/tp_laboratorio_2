using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.IO;


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
            Texto txt = new Texto();
            bool retorno = false;
            if (!(txt is null && jornada is null))
            {
                retorno = txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", jornada.ToString());
            }
            return retorno;
        }
        public static string Leer()
        {
            Texto txt = new Texto();
            string retorno = "";
            if (!(txt is null))
            {
                txt.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", out retorno);
            }
            return retorno;
        }

        override
        public string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("CLASE DE ");
            retorno.Append(this.clase);
            retorno.Append(" POR ");
            retorno.Append(this.instructor.ToString());
            retorno.AppendLine("");
            retorno.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                retorno.AppendLine(alumno.ToString());
            }
            retorno.AppendLine("<--------------------------------->");
            retorno.AppendLine("");
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
