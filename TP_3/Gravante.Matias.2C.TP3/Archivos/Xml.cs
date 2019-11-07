using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T>
    {
        #region Métodos
        public bool Guardar(string archivo, T datos)
        {
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);
            return true;
        }
        #endregion
    }
}
