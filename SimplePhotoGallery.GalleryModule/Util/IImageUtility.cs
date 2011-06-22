using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePhotoGallery.GalleryModule.Util
{
    public interface IImageUtility
    {
        string CreateVenueImageStorage(int venueId);
        System.Drawing.Image CropImage(System.Drawing.Image Image, int Height, int Width);
        System.Drawing.Image CropImage(System.Drawing.Image Image, int Height, int Width, int StartAtX, int StartAtY);
        System.Drawing.Image HardResizeImage(int Width, int Height, System.Drawing.Image Image);
        System.Drawing.Image ResizeImage(int maxWidth, int maxHeight, System.Drawing.Image Image);
        bool SavePostedFile(System.Web.HttpPostedFileBase httpPostedFileBase, string path, string fileName, bool multiSize);
    }
}
