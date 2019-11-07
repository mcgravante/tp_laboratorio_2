using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto
    {
        #region Métodos
        public bool Guardar(string archivo, string datos)
        {
            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            datos = "a completar";
            return true;
        }
        #endregion
    }
}
