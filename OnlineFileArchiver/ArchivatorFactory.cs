using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFileArchiver
{
    public enum ArchiveType
    {
        Zip,
        Rar,
        Sevenzip,
        tar
    }

    public class ArchivatorFactory
    {
        
        public static IArchivator CreateArchivator(ArchiveSettings archiveSettings) => archiveSettings.ArchiveType switch {

        ArchiveType.Zip => new ZipArchivator(),
             _ => null

        };


      
    }
}
