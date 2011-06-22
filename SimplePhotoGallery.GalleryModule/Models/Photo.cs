using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePhotoGallery.GalleryModule.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual GalleryFile PhotoFile { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsEdit { get; set; }
    }
}
