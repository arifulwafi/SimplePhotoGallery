using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using SimplePhotoGallery.GalleryModule.Configuration;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.Core.Configuration;

namespace SimplePhotoGallery.GalleryModule.Repositories.Context
{
    public class RepositoryContext : DbContext
    {
        private const int StringMaxLength = 255;

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<GalleryFile> GalleryFiles { get; set; }

        public RepositoryContext(IConnectionString connectionString)
            : base(connectionString.DefaultConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>().Property(c => c.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Photo>().Ignore(c => c.IsEdit);

            modelBuilder.Entity<Album>().Property(c => c.Title).IsRequired().HasMaxLength(255);
            //modelBuilder.Entity<Album>().Ignore(p => p.Photos);

            modelBuilder.Entity<GalleryFile>().Ignore(p => p.Content);
            modelBuilder.Entity<GalleryFile>().Ignore(p => p.HttpPostedFileBase); 
        }
    }
}
