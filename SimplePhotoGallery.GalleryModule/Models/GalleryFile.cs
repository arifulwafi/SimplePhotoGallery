using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SimplePhotoGallery.GalleryModule.Models
{
    public class GalleryFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public decimal Size { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }
        public HttpPostedFileBase HttpPostedFileBase { get; set; }
    }
}
