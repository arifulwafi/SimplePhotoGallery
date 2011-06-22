using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Services
{
    public interface IAlbumService
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
