using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Repositories;
using SimplePhotoGallery.GalleryModule.Util;
using SimplePhotoGallery.GalleryModule.Configuration;

namespace SimplePhotoGallery.GalleryModule.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IImageUtility _imageUtility;
        private readonly IGalleryModuleConfiguration _galleryModuleConfiguration;

        public PhotoService(IPhotoRepository photoRepository, IImageUtility imageUtility, IGalleryModuleConfiguration galleryModuleConfiguration)
        {
            _photoRepository = photoRepository;
            _imageUtility = imageUtility;
            _galleryModuleConfiguration = galleryModuleConfiguration;
        }

        #region Photo Services
        
        public void DeletePhoto(Guid id)
        {
            _photoRepository.DeletePhoto(id);
        }
        public Photo GetPhoto(Guid id)
        {
            return _photoRepository.GetPhoto(id);
        }
        public IEnumerable<Photo> GetPhotos()
        {
            return _photoRepository.GetPhotos();
        }
        public IEnumerable<Photo> GetPhotos(Guid albamId, int pageNo, int pageSize)
        {
            return _photoRepository.GetPhotos(albamId, pageNo, pageSize);
        }
        public void InsertPhoto(Photo photo)
        {
            _photoRepository.InsertPhoto(photo);
            if (photo.PhotoFile != null)
            {
                string path = string.Format("{0}{1}", _galleryModuleConfiguration.Get().AlbumStoragePath, photo.AlbumId.ToString());
                _imageUtility.SavePostedFile(photo.PhotoFile.HttpPostedFileBase, path, photo.PhotoFile.Id.ToString(), true);
            }
        }
        public void UpdatePhoto(Photo photo)
        {
            _photoRepository.UpdatePhoto(photo);
        }

        #endregion
    }
}
