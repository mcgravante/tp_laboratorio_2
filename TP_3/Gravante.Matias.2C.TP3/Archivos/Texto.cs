using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            if (!(archivo is null && datos is null))
            {
                StreamWriter writer = null;
                try
                {
                    using (writer = new StreamWriter(archivo))
                    {
                        writer.WriteLine(datos);
                    }
                    retorno = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                finally
                {
                    if (!(writer is null))
                    {
                        writer.Close();
                    }
                }
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";
            try
            {
                using (StreamReader aux = new StreamReader(archivo))
                {
                    datos += aux.ReadToEnd();
                }
                retorno = true;
            }
            catch (Exception)
            {
                datos = "";
                retorno = false;
            }
            return retorno;
        }
        #endregion
    }
}