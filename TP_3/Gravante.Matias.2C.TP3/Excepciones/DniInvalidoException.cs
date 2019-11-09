﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos
        private static string mensajeBase = "DNI Inválido";
        #endregion

        #region Constructores
        public DniInvalidoException() : base(mensajeBase)
        { }

        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        { }

        public DniInvalidoException(string message) : base(message)
        { }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        { }
        #endregion
    }
}
