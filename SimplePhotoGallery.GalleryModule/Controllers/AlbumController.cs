using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Services;

namespace SimplePhotoGallery.GalleryModule.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _albumService.GetAlbums();
            return View(result);
        }

        [HttpGet]
        public ActionResult View(Guid id)
        {
            return View(_albumService.GetAlbum(id));
        }
        [HttpGet]
        public ActionResult Save(Guid id)
        {
            if (id == Guid.Empty) return View();

            var result = _albumService.GetAlbum(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Save(Album album)
        {
            if (ModelState.IsValid)
            {
                if (album.Id == Guid.Empty)
                {
                    album.Id = Guid.NewGuid();
                    _albumService.InsertAlbum(album);
                }
                else
                {
                    _albumService.UpdateAlbum(album);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if(id!=Guid.Empty)
                _albumService.DeleteAlbum(id);
            return RedirectToAction("Index");
        }

        public ActionResult ChangePublishStatus(Guid id)
        {
            if (id != null)
                _albumService.ChangePublishStatus(id);
            return RedirectToAction("Index");
        }
    }
}
