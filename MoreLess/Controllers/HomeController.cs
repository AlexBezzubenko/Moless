using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoreLess.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace MoreLess.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            /*Account account = new Account(
                "dyuwhmiwj",
                "172611582566755",
                "nCtCFnTMqdT4sT_v3eYL2G9lmlk");
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"http://www.avatar-mix.ru/avatars_low_200x200/1431.jpg")
            };
            var uploadResult = cloudinary.Upload(uploadParams);*/
            
            return View(db.Lots);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult PutUpLot() => View();

        [HttpPost]
        public ActionResult PutUpLot(Lot lot)
        {
            db.Lots.Add(lot);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = Guid.NewGuid().ToString(); //file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        /*var originalDirectory =
                                 new System.IO.DirectoryInfo(
                                      string.Format("{0}Images\\uploaded", Server.MapPath(@"\")));
                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(),
                                                        "imagepath");
                        var fileName1 = System.IO.Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);
                        var path = string.Format("{0}\\{1}", pathString, fName);
                        file.SaveAs(path);*/
                        var originalDirectory =
                                 new System.IO.DirectoryInfo(
                                      string.Format("{0}Images\\uploaded", Server.MapPath(@"\")));
                        var fileName1 = System.IO.Path.GetFileName(file.FileName);
                        var path = string.Format("{0}\\{1}", originalDirectory, fName);
                        
                        Account account = new Account(
                            "dyuwhmiwj",
                            "172611582566755",
                            "nCtCFnTMqdT4sT_v3eYL2G9lmlk");
                        Cloudinary cloudinary = new Cloudinary(account);
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(path)
                        };
                        var uploadResult = cloudinary.Upload(uploadParams);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            isSavedSuccessfully = false;
                        }

                        if (isSavedSuccessfully == false)
                            return Json(new { Message = fName });
                        else
                            return Json(new { Message = "Error in saving file" });
                 }


    }
}