using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;

namespace SimplePhotoGallery.GalleryModule.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
