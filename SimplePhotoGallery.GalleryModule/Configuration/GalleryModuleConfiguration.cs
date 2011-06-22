using System.Configuration;

namespace SimplePhotoGallery.GalleryModule.Configuration
{
    public class GalleryModuleConfiguration : ConfigurationSection
    {
        public string Email
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public string AssetPath
        {
            get;
            set;
        }
        public string AssetHttpPath
        {
            get;
            set;
        }
        public string AlbumStoragePath
        {
            get;
            set;
        }
    }
}
