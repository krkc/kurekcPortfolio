using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNet.Mvc;

namespace WPortfolioSite.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        // GET api/Files/{safefilename}
        [HttpGet("{safefilename}")]
        public string Get(string safefilename)
        {
            if (safefilename != null)
            {
                string filename = safefilename.Replace('_', '.');
                FileStream fs;
                try
                {
                    fs = new FileStream("pfiles/" + filename, FileMode.Open);
                }

                catch (Exception e)
                {
                    if (e is DirectoryNotFoundException || e is FileNotFoundException)
                    {
                        return "Sorry, the file was not found.";
                    } else
                    {
                        return e.Message;
                    }
                }

                StreamReader sr = new StreamReader(fs);
                string returnString = sr.ReadToEnd();

                fs.Dispose();

                return returnString;
            } else
            {
                return "Error! You must provide a filename.";
            }
            
        }

    }
}
