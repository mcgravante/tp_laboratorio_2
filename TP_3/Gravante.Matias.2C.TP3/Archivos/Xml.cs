using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Métodos
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            if (!(archivo is null))
            {
                XmlWriter writer = null;
                try
                {
                    writer = new XmlTextWriter(archivo, Encoding.UTF8);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
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
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default;
            if (!(archivo is null))
            {
                XmlReader lector = null;
                try
                {
                    lector = new XmlTextReader(archivo);
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector);
                    retorno = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                finally
                {
                    if (!(lector is null))
                    {
                        lector.Close();
                    }
                }
            }
            return retorno;
        }
        #endregion
    }
}
