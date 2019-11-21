using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructores
        static PaqueteDAO()
        { }
        #endregion

        #region Métodos
        public static bool Insertar(Paquete p)
        {
            return false;
        }
        #endregion
    }
}
