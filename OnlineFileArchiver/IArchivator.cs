using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFileArchiver
{
    public interface IArchivator
    {
         public Task<string> CompressToFile(IFormFileCollection files, string SaveFolder);

    
    }
}
