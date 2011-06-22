using System.Configuration;
using System.Web.Configuration;

namespace SimplePhotoGallery.GalleryModule.Configuration
{
    public class WebConfigConfiguration : IGalleryModuleConfiguration
    {
        #region IGalleryModuleConfigurationRepository Members

        public GalleryModuleConfiguration Get()
        {
            var _configuration =
                WebConfigurationManager.GetSection("galleryModule") as WebConfigSection;
            return new GalleryModuleConfiguration
            {
                ConnectionString =
                    ConfigurationManager.ConnectionStrings[_configuration.SqlConnectionStringName].
                    ConnectionString,
                Email = _configuration.Email,

                AssetPath = _configuration.Resources.AssetPath,
                AssetHttpPath = _configuration.Resources.AssetHttpPath,
                AlbumStoragePath = _configuration.Resources.AlbumStoragePath
            };
        }

        #endregion
    }
}
