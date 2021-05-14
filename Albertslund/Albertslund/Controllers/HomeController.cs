using Albertslund.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserLogged = HttpContext.Session.GetInt32("SessionUserId");
            ViewBag.SessionSuccess = HttpContext.Session.GetInt32("SessioSuccess");
            Reader();


            return View();
       
        }


        public void Reader()
        {
            String WatchingHere = @"E:\School\Code Practice\C#\Exam Project\New CSV";
            var fileSystemWatcher = new FileSystemWatcher(WatchingHere)
            {
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes,
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Created += ActionOccurOnFileCreated;
            fileSystemWatcher.Deleted += ActionOccurOnFileDeled;
            fileSystemWatcher.Renamed += ActionOccurOnFileRenamed;
            Debug.WriteLine("File System Watcher is now running." +
                "\nThe following path is being monitored: '" + WatchingHere + "'." +
                "\nAny changes made will appear below.");
        }

        private void ActionOccurOnFileCreated(object sender, FileSystemEventArgs e)
        {
            String TheNewFile = e.Name;
            String TheNewFilePath = Path.GetFullPath(TheNewFile);
            Debug.WriteLine("*** Hey! A new file was added.");
            Debug.WriteLine(e.ChangeType + ".");
            Debug.WriteLine(TheNewFile);
            Debug.WriteLine("The full filepath of the newly added .csv is:");
            Debug.WriteLine(TheNewFilePath);
            Debug.WriteLine("The file" + TheNewFile + " will now be read and saved in the database.");
            
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;
            if (context.createDBEntries(TheNewFilePath))
            {
                Debug.WriteLine("Wrote to DB");
            }
        }

        private void ActionOccurOnFileDeled(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine("*** The following file has been deleted:");
            Debug.WriteLine(e.ChangeType + ".");
            Debug.WriteLine(e.Name);
        }

        private void ActionOccurOnFileRenamed(object sender, RenamedEventArgs e)
        {
            Debug.WriteLine("*** The following file has been renamed:");
            Debug.WriteLine($"The old file name was: '{e.OldName}'.");
            Debug.WriteLine($"The new file name is: '{e.Name}'.");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
