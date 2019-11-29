using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoSqlException(string msg);

    public static class PaqueteDAO
    {
        #region Campos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructores
        static PaqueteDAO()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = ".\\SQLEXPRESS";
            sqlConnectionString.InitialCatalog = "correo-sp-2017";
            sqlConnectionString.IntegratedSecurity = true;
            conexion = new SqlConnection(sqlConnectionString.ToString());
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        #endregion

        #region Métodos
        /// <summary>
        ///  se encargará de guardar los datos de un paquete en la base de datos generada 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool ret = false;
            if (p is null)
            {
                return ret;
            }
            comando.CommandText = String.Format($"INSERT INTO dbo.Paquetes(direccionEntrega,trackingID,alumno) VALUES('{p.DireccionEntrega}','{p.TrackingID}','Matias Gravante')");
            try
            {
                conexion.Open();
                if (comando.ExecuteNonQuery() != 0)
                {
                    ret = true;
                }
            }
            catch (Exception e)
            {
                sqlError.Invoke(e.Message);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }
        #endregion

        #region Eventos
        public static event DelegadoSqlException sqlError;
        #endregion
    }
}

