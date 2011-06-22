using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Services
{
    public interface IPhotoService
    {
        void DeletePhoto(Guid id);
        Photo GetPhoto(Guid id);
        IEnumerable<Photo> GetPhotos();
        void InsertPhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        IEnumerable<Photo> GetPhotos(Guid albamId, int pageNo, int pageSize);
    }
}
