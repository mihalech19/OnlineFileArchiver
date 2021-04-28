using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;

namespace OnlineFileArchiver
{


    class ZipArchivator : IArchivator
    {

        public enum CompressLevel
        {
            Optimal = CompressionLevel.Optimal,
            Fastest = CompressionLevel.Fastest,
            NoCompression = CompressionLevel.NoCompression,

        }


        private CompressLevel compressLevel { get; set; }

        private const string fileExt = ".zip";

        public ZipArchivator()
        {

            compressLevel = CompressLevel.Optimal;
        }


        public async Task<string> CompressToFile(IFormFileCollection files, string SaveFolder)
        {

            string path = SaveFolder + @"/Files/" + Path.GetFileNameWithoutExtension(files[0].FileName) + fileExt;

            using var fileStream = new FileStream(path, FileMode.Create);
            using var archive = new ZipArchive(fileStream, ZipArchiveMode.Create);
            foreach (IFormFile file in files)
            {
                var archiveEntry = archive.CreateEntry(file.FileName, (CompressionLevel)compressLevel);
                using var entryStream = archiveEntry.Open();
                await file.CopyToAsync(entryStream);
            }
            return path;

        }



    }
}
