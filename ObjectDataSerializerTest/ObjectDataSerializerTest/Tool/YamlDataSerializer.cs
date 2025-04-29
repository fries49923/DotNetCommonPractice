using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ObjectDataSerializerTest.Tool
{
    public class YamlDataSerializer : IDataSerializer
    {
        private readonly ISerializer serializer;
        private readonly IDeserializer deserializer;

        public YamlDataSerializer()
        {
            serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public byte[] SerializeToByteAry<T>(T obj)
            where T : class
        {
            try
            {
                var yaml = serializer.Serialize(obj);

                return System.Text.Encoding.UTF8.GetBytes(yaml);
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
                var yaml = System.Text.Encoding.UTF8.GetString(byteAry);

                return deserializer.Deserialize<T>(yaml);
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
                return serializer.Serialize(obj);
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
                return deserializer.Deserialize<T>(str);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}