using System;
using System.Collections.Generic;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Repositories
{
    public interface IAlbumRepository
    {
        void DeleteAlbum(Guid id);
        Album GetAlbum(Guid id);
        IEnumerable<Album> GetAlbums();
        IEnumerable<Album> GetPublishedAlbums();
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        void ChangePublishStatus(Guid id);
    }
}
