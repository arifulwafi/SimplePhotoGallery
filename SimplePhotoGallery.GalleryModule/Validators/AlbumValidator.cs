using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using SimplePhotoGallery.GalleryModule.Models;

namespace SimplePhotoGallery.GalleryModule.Validators
{
    public class AlbumValidator : AbstractValidator<Album>
    {
        public AlbumValidator()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage("Please specify a album title");
        }
    }
}
