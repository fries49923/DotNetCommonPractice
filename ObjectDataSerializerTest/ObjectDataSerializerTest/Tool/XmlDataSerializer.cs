using System.IO;
using System.Xml.Serialization;

namespace ObjectDataSerializerTest.Tool
{
    public class XmlDataSerializer : IDataSerializer
    {
        public byte[] SerializeToByteAry<T>(T obj)
            where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var mStream = new MemoryStream();
                serializer.Serialize(mStream, obj);

                return mStream.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T DeserializeFromByteAry<T>(byte[] byteAry)
            where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var mStream = new MemoryStream(byteAry);
                var obj = serializer.Deserialize(mStream);

                if (obj is not T result)
                {
                    throw new Exception("Deserialize fail");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SerializeToString<T>(T obj)
            where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var writer = new StringWriter();
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T DeserializeFromString<T>(string str)
            where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var reader = new StringReader(str);
                var obj = serializer.Deserialize(reader);

                if (obj is not T result)
                {
                    throw new Exception("Deserialize fail");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
