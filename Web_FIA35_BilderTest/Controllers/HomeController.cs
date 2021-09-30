using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_FIA35_BilderTest.Models;

namespace Web_FIA35_BilderTest.Controllers
{
    public class HomeController : Controller
    {
        // Hierin befinden sich alle Informationen zur Umgebung des Webprojekts
        // "readonly" bewirkt, dass es keine Änderungen geben kann (außer durch den Konstruktor beim Erzeugen der neuen Instanz am Anfang)
        // "private" müsste nicht extra gesetzt werden, weil alle Methoden per Standard auf "private" gesetzt sind
        private readonly IWebHostEnvironment Environment;

        public HomeController(IWebHostEnvironment _environment)  // Konstruktor ist "public", weil sonst keine Instanz von außen erzeugt wird
        {
            Environment = _environment;
        }        

        public IActionResult Index()
        {
            // Aus Array wird Liste
            int[] vieleInts = new int[] { 4, 2, 7, 5, 55, 4, -11 };
            List<int> intListe = new List<int>(vieleInts);
            // Aus Liste wird Array
            int[] intArray = intListe.ToArray();

            // 
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            DirectoryInfo di = new DirectoryInfo(wwwPath + "\\Bilder");
            FileInfo[] fi = di.GetFiles("*.*");
            List<FileInfo> DateiListe = new List<FileInfo>(fi);

            // Alternative 1
            List<FileInfo> DateiListe2 = di.GetFiles("*.*").ToList();

            // Alternative 2
            List<FileInfo> DateiListe3 = new List<FileInfo>(di.GetFiles("*.*"));

            // Alternative 3
            string[] filesInRootDir = Directory.GetFiles(wwwPath);
            List<string> DateiListe4 = filesInRootDir.ToList();

            DateiInfos Infos = new DateiInfos { DateiListe = DateiListe3 };

            return View(Infos);
        }
    }
}
