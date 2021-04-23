using ImageAnalizer.Models;
using ImageAnalizer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAnalizer.Controllers
{
    public class ComputerVisionController : Controller
    {
        ServiceImages ServiceApi;

        public ComputerVisionController(ServiceImages serviceapi)
        {
            this.ServiceApi = serviceapi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string urlImagen)
        {
            ImageAnalysis datosImagen = await this.ServiceApi.Analizer(urlImagen);
            return View(datosImagen);
        }
        
        public IActionResult Vista()
        {
            return View();
        }
        
    }
}