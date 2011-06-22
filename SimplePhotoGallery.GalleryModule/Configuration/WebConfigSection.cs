using System.Configuration;
using System.Web.Configuration;

namespace SimplePhotoGallery.GalleryModule.Configuration
{
    public class WebConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("resources")]
        public ResourcesElement Resources
        {
            get { return (ResourcesElement)base["resources"]; }
        }

        [ConfigurationProperty("email", DefaultValue = "")]
        public string Email
        {
            get { return (string)base["email"]; }
            set { base["email"] = value; }
        }

        [ConfigurationProperty("sqlConnectionStringName", DefaultValue = "")]
        public string SqlConnectionStringName
        {
            get { return (string)base["sqlConnectionStringName"]; }
            set { base["sqlConnectionStringName"] = value; }
        }
    }
}
