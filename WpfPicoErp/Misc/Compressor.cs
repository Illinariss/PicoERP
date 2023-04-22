using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPicoErp.Misc
{
    public static class Compressor
    {
        public static byte[] Compress(byte[] data)
        {
            using var compressedStream = new MemoryStream();
            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                gzipStream.Write(data, 0, data.Length);
            }
            return compressedStream.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            using var decompressedStream = new MemoryStream();
            using (var compressedStream = new MemoryStream(data))
            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            {
                gzipStream.CopyTo(decompressedStream);
            }
            return decompressedStream.ToArray();
        }


    }
}
