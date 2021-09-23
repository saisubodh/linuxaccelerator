using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hackathon.Models;
using System.Reflection.Emit;
using Newtonsoft.Json;

namespace hackathon.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var response = new
            {msg="Welcome to Linux Accelerator" };
            return Ok(response);
        }
    }
    [Route("/GetMetadata")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        [HttpGet]
        public IActionResult get(string repo)
        {
            string path = "./project";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory("path");
                LibGit2Sharp.Repository.Clone("https://github.com/saisubodh/hackathon.git", path);

            }
            //string json= "";
            //if (!Directory.Exists(path))
            //    return Ok("could not find file");
            /*using (StreamReader r = new StreamReader(@"../../project/metadata.json"))
            {
                json = r.ReadToEnd();
            }
            */
            string json = System.IO.File.ReadAllText("./project/metadata.json");
            JsonConvert.DeserializeObject<MetadataModel>(json);
            return Ok(json);
        }
    }
}
