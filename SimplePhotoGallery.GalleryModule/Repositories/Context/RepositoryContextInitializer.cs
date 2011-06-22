using System;
using System.Data.Entity;
using System.Linq;
using SimplePhotoGallery.Core.Configuration;
using System.Collections.Generic;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Repositories.Context
{
    public class RepositoryContextInitializer : DropCreateDatabaseIfModelChanges<RepositoryContext>, IRepositoryContextInitializer
    {
        private readonly RepositoryContext _dbContext;

        public RepositoryContextInitializer(RepositoryContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void InitializeDatabase()
        {
            InitializeDatabase(_dbContext);
        }

        protected override void Seed(RepositoryContext context)
        {
            context.SaveChanges();
        }
    }
}
