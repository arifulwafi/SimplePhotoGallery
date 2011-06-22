using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePhotoGallery.Core.Configuration
{
    public interface IRepositoryContextInitializer
    {
        void InitializeDatabase();
    }
}
