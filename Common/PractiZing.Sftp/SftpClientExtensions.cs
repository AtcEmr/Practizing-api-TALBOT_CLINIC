using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Sftp
{
    public static class SftpClientExtensions
    {
        public static async Task<string[]> ReadAllLinesAsync(this SftpClient client, string path, Encoding encoding)
        {
         
            var bytes = await client.ReadAllBytesAsync(path);

            var list = new List<string>();
            using (var stream = new MemoryStream(bytes))
            using (var reader = new StreamReader(stream, encoding))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(line);
                }
            }

            return list.ToArray();
        }

        public static async Task<string> ReadAllTextAsync(this SftpClient client, string path, Encoding encoding)
        {   
            var bytes = await client.ReadAllBytesAsync(path);
            using (var stream = new MemoryStream(bytes))
            using (var reader = new StreamReader(stream, encoding))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task UploadAllLinesAsync(this SftpClient client, string path, IEnumerable<string> contents, Encoding encoding, bool canOverride = true)
        {
          
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding))
            {
                foreach (var content in contents)
                    writer.WriteLine(content);

                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                await client.UploadAsync(path, stream, canOverride);
            }
        }

        public static async Task UploadAllTextAsync(this SftpClient client, string path, string contents, Encoding encoding, bool canOverride = true)
        {
           using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding))
            {
                writer.Write(contents);

                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                await client.UploadAsync(path, stream, canOverride);
            }
        }

        

        public static async Task WriteAllLinesAsync(this SftpClient client, string path, IEnumerable<string> contents, Encoding encoding)
        {
           
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding))
            {
                foreach (var content in contents)
                    writer.WriteLine(content);

                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                await client.WriteAllBytesAsync(path, stream.ToArray());
            }
        }

        public static async Task WriteAllTextAsync(this SftpClient client, string path, string contents, Encoding encoding)
        {
      

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding))
            {
                await writer.WriteAsync(contents);

                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                await client.WriteAllBytesAsync(path, stream.ToArray());
            }
        }

        public static async Task WriteAllTextAsync(this SftpClient client, string path, string contents)
        {
            await client.WriteAllTextAsync(path, contents);
        }
    }
}