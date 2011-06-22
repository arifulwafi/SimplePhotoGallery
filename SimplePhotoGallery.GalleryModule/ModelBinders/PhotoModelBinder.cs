using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplePhotoGallery.GalleryModule.Models;
using Autofac.Integration.Mvc;

namespace SimplePhotoGallery.GalleryModule.ModelBinders
{
    [ModelBinderType(typeof(Photo))]
    public class PhotoModelBinder:IModelBinder
    {
        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;

            var tempId = controllerContext.RouteData.Values["id"];
            Guid id = tempId != null ? tempId.ToString().ToGuid() : Guid.NewGuid();

            var tempAlbumId = form["AlbumId"];
            Guid albumId = tempAlbumId != null ? tempAlbumId.ToString().ToGuid() : Guid.Empty;

            string title = form["Title"];
            string description = form["Description"];

            DateTime created = default(DateTime);
            string tempCreated = form["Created"];
            DateTime.TryParse(tempCreated, out created);

            bool isEdit = false;
            string tempIsEdit = form["IsEdit"];
            bool.TryParse(tempIsEdit, out isEdit);
            GalleryFile photoFile = null;

            if (controllerContext.HttpContext.Request.Files.Count > 0)
            {
                HttpPostedFileBase file = controllerContext.HttpContext.Request.Files[0];
                string fileName = file.FileName;
                byte[] content = new byte[file.ContentLength];
                string fileExtension = Path.GetExtension(file.FileName);
                string mimeType = file.ContentType;
                long size = file.ContentLength;
                file.InputStream.Read(content, 0, content.Length);
                if (!string.IsNullOrEmpty(fileName))
                    photoFile = new GalleryFile
                                    {
                                        HttpPostedFileBase = file,
                                        Content = content,
                                        Extension = fileExtension,
                                        Id = id,
                                        MimeType = mimeType,
                                        Name = fileName
                                    };
            }

            return new Photo
                       {
                           AlbumId = albumId,
                           Created = created,
                           Description = description,
                           Id = id,
                           PhotoFile = photoFile,
                           Title = title,
                           Updated=DateTime.Now,
                           IsEdit=isEdit
                       };
        }

        #endregion
    }
}