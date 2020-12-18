using Microsoft.AspNetCore.Mvc;
using System;
using HW_4_StartMVC.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;
using System.Text;
using HW_4_StartMVC.Models;


namespace HW_4_StartMVC.Controllers
{
   
    public class TemperatureToController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("convert")]
        public IActionResult TemperatureConverter()
        {
            return View("TemperatureConverter");
        }

        [HttpPost]
        [ActionName("convert")]
        public IActionResult TemperatureConverter(double temperature,
                                                  [FromServices] IValidatorForTemperature validatorForTemperature,
                                                  [FromServices] ITemperatureConverter converter)
        {
            if (validatorForTemperature.Valid(temperature))
            {
                ViewBag.temperature = temperature;  //лишнее?
                ViewBag.result = converter.Convert(temperature);
                ViewBag.answer = $"{temperature + converter.Name}  =  {converter.Convert(temperature) +converter.ConvertDirection}";
                return View("TemperatureAnswer");
            }
            else
            {
                return BadRequest("wrong temperature");
            }
        }

        [HttpPost]
        public  IActionResult SaveAndSend(   [FromServices]IWebHostEnvironment webHostEnvironment,                                            
                                            string result, 
                                            ChooseType chooseType )
        {
            string patchToProject = webHostEnvironment.ContentRootPath;
            string absPatchToFile;
            string patchToFile;

            switch (chooseType)
            {
                case ChooseType.zip:
                case ChooseType.txt:
                    patchToFile = @"wwwroot\files\answer.txt";
                    absPatchToFile = Path.Combine(patchToProject, patchToFile);

                    try
                    {
                        using StreamWriter sw = new StreamWriter(absPatchToFile, false);
                        sw.Write(result);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500);
                    }
                    if (chooseType == ChooseType.txt )
                        return PhysicalFile(absPatchToFile, "text/plain", "Converted Temperuture.txt");

                    string soutceToZip = absPatchToFile;  
                    patchToFile = @"wwwroot\files\answer.zip";
                    absPatchToFile = Path.Combine(patchToProject, patchToFile);                    

                    try
                    {
                        using var outputStream = new FileStream(absPatchToFile, FileMode.Create, FileAccess.ReadWrite);
                        using var archive = new ZipArchive(outputStream, ZipArchiveMode.Create);
                        archive.CreateEntryFromFile(soutceToZip, Path.GetFileName(soutceToZip), CompressionLevel.Optimal);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500);
                    }
                        return PhysicalFile(absPatchToFile, "application/zip", "Converted Temperuture.zip");
                    
                case ChooseType.byteStream:
                    byte[] resultInByte = Encoding.ASCII.GetBytes(result);
                    MemoryStream memoryStream = new MemoryStream(resultInByte);                    
                    return new FileStreamResult(memoryStream, "text/plain");
                default: return StatusCode(500);
            }                  
        }

        [HttpGet]
        public IActionResult RedirectExample()
        {
            return  Redirect("https://it-academy.by");
        }

    }
}
