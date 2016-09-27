using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoreLess.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;

namespace MoreLess.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();

            //IEnumerable<Lot> userLots = db.Lots.Include(x => x.ApplicationUser).Where(x => x.ApplicationUser == currentUser);
            
            //IEnumerable<Lot> lots = db.Lots.Include(x => x.ApplicationUser);

            return View(db.Lots.Where(x => x.ApplicationUser.Id == currentUserId).Include(x=>x.ApplicationUser));
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

        [Authorize]
        [HttpGet]
        public ActionResult PutUpLot() => View();

        [Authorize]
        [HttpPost]
        public ActionResult PutUpLot(Lot lot)
        {
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var currentUser = db.Users.Find(User.Identity.GetUserId());
            //var userBlogs = db.Blogs.Where(x => x.ApplicationUser == currentUser);

            lot.ApplicationUser = currentUser;
            db.Lots.Add(lot);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string ImageUrl = "";

            try
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file != null)
                {
                    Account account = new Account(
                            "dyuwhmiwj",
                            "172611582566755",
                            "nCtCFnTMqdT4sT_v3eYL2G9lmlk");
                    Cloudinary cloudinary = new Cloudinary(account);
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(System.IO.Path.GetFileName(file.FileName), file.InputStream)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    ImageUrl = @"http://res.cloudinary.com/dyuwhmiwj/image/upload/v1474217285/" + uploadResult.PublicId + ".jpg";
                }
              }
              catch (Exception ex)
              {
                  isSavedSuccessfully = false;
              }

              if (isSavedSuccessfully == true)
                  return Json(new { Message = ImageUrl });
              else
                  return Json(new { Message = "Error in saving file" });
         }

        public ActionResult ViewLot(int? id)
        {

            //ViewBag.Message = lot.Title;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

    }
}