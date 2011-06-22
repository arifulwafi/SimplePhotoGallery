using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Repositories;

namespace SimplePhotoGallery.GalleryModule.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        #region Album Services
        
        public void DeleteAlbum(Guid id)
        {
            _albumRepository.DeleteAlbum(id);
        }
        public Album GetAlbum(Guid id)
        {
            return _albumRepository.GetAlbum(id);
        }
        public IEnumerable<Album> GetAlbums()
        {
            return _albumRepository.GetAlbums();
        }
        public IEnumerable<Album> GetPublishedAlbums()
        {
            return _albumRepository.GetPublishedAlbums();
        }
        public void InsertAlbum(Album album)
        {
            _albumRepository.InsertAlbum(album);
        }
        public void UpdateAlbum(Album album)
        {
            _albumRepository.UpdateAlbum(album);
        }

        public void ChangePublishStatus(Guid id)
        {
            _albumRepository.ChangePublishStatus(id);
        }

        #endregion
    }
}
