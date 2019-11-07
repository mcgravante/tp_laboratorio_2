﻿using System;
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
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos
        override
        public string ToString()
        {
            return "a completar";
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dni < 1 || dni > 99999999)
            {
                throw new DniInvalidoException("DNI fuera de rango");
            }
            else if (nacionalidad.Equals(ENacionalidad.Extranjero) && dni < 90000000)
            {
                throw new NacionalidadInvalidaException("No corresponde la nacionalidad");
            }
            else if (nacionalidad.Equals(ENacionalidad.Argentino) && dni > 89999999)
            {
                throw new NacionalidadInvalidaException("No corresponde la nacionalidad");
            }
            return dni;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!int.TryParse(dato, out int dni))
            {
                throw new DniInvalidoException("DNI inválido", e);
            }
            return ValidarDni(nacionalidad, dni);
        }


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
