using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos
        private string mensajeBase;
        #endregion

        #region Constructores
        public DniInvalidoException() : base()
        { }

        public DniInvalidoException(Exception e) : this()
        { }

        public DniInvalidoException(string message) : this()
        { }

        public DniInvalidoException(string message, Exception e) : this(message)
        { }
        #endregion
    }
}
