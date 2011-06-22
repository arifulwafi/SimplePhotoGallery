using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePhotoGallery.GalleryModule.Models;
using FluentValidation;

namespace SimplePhotoGallery.GalleryModule.Validators
{
    public class PhotoValidator : AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(model => model.AlbumId).NotEmpty().WithMessage("Please specify a album");
            RuleFor(model => model.Title).NotEmpty().WithMessage("Please specify a photo title");
            RuleFor(model => model.PhotoFile).NotNull().WithMessage("Please specify a valid image.").When(
                 model =>
                    model.PhotoFile != null && !model.PhotoFile.Extension.IsPhoto());
        }
    }
}
