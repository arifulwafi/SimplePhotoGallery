using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.ModelBinders
{
    public class PhotoModelBinder:IModelBinder
    {
        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;

            var tempId = controllerContext.HttpContext.Request.QueryString["id"];
            Guid id = tempId != null ? tempId.ToString().ToGuid() : Guid.NewGuid();

            var tempAlbumId = form["AlbumId"];
            Guid albumId = tempAlbumId != null ? tempAlbumId.ToString().ToGuid() : Guid.Empty;

            string title = form["Title"];
            string tempSequence = form["Sequence"];
            int sequence = default(int);
            int.TryParse(tempSequence, out sequence);
            string tempAccessTypeId = form["AccessTypeId"];
            int accessTypeId = default(int);
            int.TryParse(tempAccessTypeId, out accessTypeId);
            string description = form["Description"];

            bool isEdit = false;
            bool.TryParse(form["IsEdit"], out isEdit);

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
                           Created = DateTime.Now,
                           Description = description,
                           Id = id,
                           PhotoFile = photoFile,
                           Title = title
                       };
        }

        #endregion
    }
}