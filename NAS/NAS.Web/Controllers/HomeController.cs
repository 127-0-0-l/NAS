using NAS.Logic.Managers.Interfaces;
using NAS.Web.Models;
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

        public ActionResult Index(string path = null)
        {
            FolderContentModel fcm = new FolderContentModel();
            fcm.Folders = new List<FolderModel>();
            fcm.Files = new List<FileModel>();
            fcm.Path = "~\\";
            return View(fcm);
        }

        public ActionResult Home()
        {
            FolderContentModel fcm = new FolderContentModel();
            fcm.Folders = new List<FolderModel>();
            fcm.Files = new List<FileModel>();
            fcm.Path = "C:\\hello\\world\\";
            return PartialView("Index", fcm);
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