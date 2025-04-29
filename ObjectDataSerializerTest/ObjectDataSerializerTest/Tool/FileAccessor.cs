using System.IO;
using System.Text;

namespace ObjectDataSerializerTest.Tool
{
    public class FileAccessor
    {
        public void WriteBytes(string filePath, byte[] data)
        {
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            fs.Write(data, 0, data.Length);
        }

        public byte[] ReadBytes(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var ms = new MemoryStream();
            fs.CopyTo(ms);

            return ms.ToArray();
        }

        public void WriteText(string filePath, string text)
        {
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(fs, Encoding.UTF8);
            writer.Write(text);
        }

        public string ReadText(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fs, Encoding.UTF8);

            return reader.ReadToEnd();
        }
    }

}
