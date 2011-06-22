using System;
using System.Collections.Generic;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Repositories
{
    public interface IPhotoRepository
    {
        void DeletePhoto(Guid id);
        Photo GetPhoto(Guid id);
        IEnumerable<Photo> GetPhotos();
        IEnumerable<Photo> GetPhotos(Guid albamId, int pageNo, int pageSize);
        void InsertPhoto(Photo photo);
        void UpdatePhoto(Photo photo);
    }
}
