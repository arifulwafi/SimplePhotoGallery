using System.Configuration;
using System.Web.Configuration;

namespace SimplePhotoGallery.GalleryModule.Configuration
{
    public class ResourcesElement : ConfigurationElement
    {
        [ConfigurationProperty("assetPath")]
        public string AssetPath
        {
            get { return (string)base["assetPath"]; }
            set { base["assetPath"] = value; }
        }
        [ConfigurationProperty("assetHttpPath")]
        public string AssetHttpPath
        {
            get { return (string)base["assetHttpPath"]; }
            set { base["assetHttpPath"] = value; }
        }
        [ConfigurationProperty("albumStoragePath")]
        public string AlbumStoragePath
        {
            get { return (string)base["albumStoragePath"]; }
            set { base["albumStoragePath"] = value; }
        }
    }
}
