using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Repositories.Context;

namespace SimplePhotoGallery.GalleryModule.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RepositoryContext _context;

        public AlbumRepository(RepositoryContext context)
         {
             _context = context;
         }

        #region Photo CRUD

        public void InsertAlbum(Album album)
        {
            album.Created = DateTime.Now;
            album.Updated = DateTime.Now;
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void UpdateAlbum(Album album)
        {
            album.Updated = DateTime.Now;
            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _context.Albums.ToList();
        }

        public IEnumerable<Album> GetPublishedAlbums()
        {
            return _context.Albums.Where(x=>x.Publish==true).ToList();
        }

        //public Album GetAlbum(Guid id)
        //{
        //    return _context.Albums.Find(id);
        //}

        public Album GetAlbum(Guid id)
        {
            var result = _context.Albums.Include(x=>x.Photos).FirstOrDefault(x=>x.Id==id);
            return result;
        }

        public void DeleteAlbum(Guid id)
        {
            Album album = _context.Albums.Find(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public void ChangePublishStatus(Guid id)
        {
            Album album = _context.Albums.Find(id);
            album.Publish = album.Publish ? false : true;
            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();

        }
        #endregion
    }
}
