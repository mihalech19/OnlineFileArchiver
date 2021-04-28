using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFileArchiver.Pages
{
    public class IndexModel : PageModel
    {
        public int ret;
        IWebHostEnvironment _appEnvironment;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }


        public async Task<IActionResult> OnPost(IFormFileCollection uploadedFiles, string archiveType)
        {
            if (uploadedFiles != null)
            {

                ArchiveSettings settings = new ArchiveSettings(archiveType);
                IArchivator archivator = ArchivatorFactory.CreateArchivator(settings);
                if (archivator != null)
                {
                    try
                    {

                        string archivePath = await archivator.CompressToFile(uploadedFiles, _appEnvironment.WebRootPath);
                        return PhysicalFile(archivePath, "application/" + Path.GetExtension(archivePath), Path.GetFileName(archivePath));
                    }
                    catch (Exception e)
                    {
                        return Content(e.Message);

                    }
                }
                else
                    return Content("Error: Cannot create an archivator");
            }
            return RedirectToAction("Index");
        }
    }


}

