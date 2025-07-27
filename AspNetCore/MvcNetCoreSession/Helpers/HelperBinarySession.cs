using System.Runtime.Serialization.Formatters.Binary;

namespace MvcNetCoreSession.Helpers
{
    public class HelperBinarySession
    {
        // Vamos a crear dos métodos static
        // porque no necesitamos realizar new para
        // utilizar los métodos de conversión que crearemos
        // en esta clase convertimos un objeto a byte[]
        public static byte[] ObjectToByte(Object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }

        // Conversor de byte[] a objeto
        public static Object ByteToObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object objeto = (Object) formatter.Deserialize(stream);
                return objeto;
            }
        }
    }
}
