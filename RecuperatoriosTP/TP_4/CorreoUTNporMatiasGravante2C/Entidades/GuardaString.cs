using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        ///  guardará en un archivo de texto en el escritorio de la máquina.
        ///  Recibirá como parámetro el nombre del archivo.
        ///  Si el archivo existe, agregará información en él
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool ret = false;
            if (archivo != null && texto != null)
            {
                string fileRoute = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" +archivo;
                StreamWriter writer = new StreamWriter(fileRoute, File.Exists(fileRoute));
                try
                {
                    writer.WriteLine(texto);
                    ret = true;
                }
                catch (Exception e)
                {
                    throw new Exception("Archivo no se pudo escribir", e);

                }
                finally
                {
                    writer.Close();

                }
            }
            return ret;
        }
    }
}
