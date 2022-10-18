using StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


Compressor compressor = new Compressor("zip");
Client client = new Client();
client.Files = new List<string> { "imagestuff.txt", "movies.flac" };

compressor.PerformCompression(client);
compressor.SwitchCompressionMethod("rar");
compressor.PerformCompression(client);

namespace StrategyPattern
{
   
    public class Client
    {
        public List<string> Files { get; set; } = new List<string>();
    }

    public class Compressor
    {
        public ICompressionBehaviour CompressionBehaviour { get; set; }

        public void SwitchCompressionMethod(string type)
        {
            switch (type.ToLower())
            {
                case "rar":
                    CompressionBehaviour = new RARCompressionBehaviour();
                    break;
                case "zip":
                    CompressionBehaviour = new ZipCompressionBehaviour();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public Compressor(string compressorType)
        {
            SwitchCompressionMethod(compressorType);
        }

        public void PerformCompression(Client client)
        {
            CompressionBehaviour.Compress(client.Files);
        }
    }

    public interface ICompressionBehaviour
    {
        public string Compress(List<string> files);
    }

    public class RARCompressionBehaviour: ICompressionBehaviour
    {
        public string Compress(List<string> files)
        {
            Console.WriteLine($"Compressed {files.Count} into a RAR file.");
            return $"rarified{files.Count}files.rar";
        }
    }

    public class ZipCompressionBehaviour: ICompressionBehaviour
    {
        public string Compress(List<string> files)
        {
            Console.WriteLine($"Compressed {files.Count} into a zip file.");
            return $"zipped{files.Count}files.zip";
        }
    }
}
