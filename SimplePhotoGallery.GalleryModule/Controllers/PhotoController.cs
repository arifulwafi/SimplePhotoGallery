using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Services;

namespace SimplePhotoGallery.GalleryModule.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;

        public PhotoController(IPhotoService photoService, IAlbumService albumService)
        {
            _photoService = photoService;
            _albumService = albumService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _photoService.GetPhotos();
            return View(result);
        }

        [HttpGet]
        public ActionResult Save(Guid id)
        {
            ViewBag.AlbumId = _albumService.GetPublishedAlbums().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
            if (id == Guid.Empty) return View();

            var result = _photoService.GetPhoto(id);
            result.IsEdit = true;
            return View(result);
        }

        [HttpPost]
        public ActionResult Save(Photo photo)
        {
            ViewBag.AlbumId = _albumService.GetPublishedAlbums().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
            if (photo != null && photo.AlbumId == Guid.Empty)
            {
                ModelState.AddModelError("Error", "Please specify a album");
                return View(photo);
            }
            if (ModelState.IsValid)
            {
                if (photo.IsEdit)
                    _photoService.UpdatePhoto(photo);
                else
                    _photoService.InsertPhoto(photo);
                return RedirectToAction("Index");
            }
            
            return View(photo);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if(id!=Guid.Empty)
                _photoService.DeletePhoto(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetPhotos(Guid albamId, int pageNo)
        {
            var result =_photoService.GetPhotos(albamId, pageNo, (int)ContentInfo.PageSize);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
