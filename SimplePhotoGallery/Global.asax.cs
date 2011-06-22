using System.Collections.ObjectModel;
using SimplePhotoGallery.Core;

namespace SimplePhotoGallery
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : Host
    {
        protected override void RegisterModules(Collection<ModuleBase> modules)
        {
            modules.Add(new SimpleGalleryModule());
        }
    }
}