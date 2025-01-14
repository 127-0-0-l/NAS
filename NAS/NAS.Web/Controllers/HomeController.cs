using NAS.Logic.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDiskManager _diskManager;
        private readonly IPartitionManager _partitionManager;
        private readonly IFolderManager _folderManager;
        private readonly IFileManager _fileManager;

        public HomeController(IDiskManager diskManager, IPartitionManager partitionManager,
            IFolderManager folderManager, IFileManager fileManager)
        {
            _diskManager = diskManager;
            _partitionManager = partitionManager;
            _folderManager = folderManager;
            _fileManager = fileManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return PartialView("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}