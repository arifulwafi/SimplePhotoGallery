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
    public class PhotoRepository : IPhotoRepository
    {
         private readonly RepositoryContext _context;

         public PhotoRepository(RepositoryContext context)
         {
             _context = context;
         }

        #region Photo CRUD

        public void InsertPhoto(Photo photo)
        {
            photo.Created = DateTime.Now;
            photo.Updated = DateTime.Now;
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void UpdatePhoto(Photo photo)
        {
            photo.Updated = DateTime.Now;
            _context.Entry(photo).State = EntityState.Modified;
            //var existingResult = _context.Photos.FirstOrDefault(x => x.Id == photo.Id);

            //_context.Entry(existingResult).CurrentValues.SetValues(photo);
            _context.SaveChanges();
        }

        public IEnumerable<Photo> GetPhotos()
        {
            return _context.Photos.Include(x=>x.Album).ToList();
        }

        public IEnumerable<Photo> GetPhotos(Guid albamId, int pageNo, int pageSize)
        {
            return _context.Photos.Include(x=>x.Album).Where(x=>x.AlbumId==albamId).Take(pageNo*pageSize).ToList();
        }
        public Photo GetPhoto(Guid id)
        {
            return _context.Photos.Find(id);
        }

        public void DeletePhoto(Guid id)
        {
            Photo photo = _context.Photos.Find(id);
            DeletePhotoFile(id);
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public void DeletePhotoFile(Guid id)
        {
            GalleryFile photo = _context.GalleryFiles.Find(id);
            _context.GalleryFiles.Remove(photo);
            _context.SaveChanges();
        }

        #endregion
    }
}
