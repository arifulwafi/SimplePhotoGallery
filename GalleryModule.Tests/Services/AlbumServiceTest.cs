using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SimplePhotoGallery.GalleryModule.Services;
using SimplePhotoGallery.GalleryModule.Models;

namespace GalleryModule.Tests.Services
{
    [TestFixture]
    public class AlbumServiceTest
    {
        public AlbumServiceTest()
        {
        }

        [SetUp]
        public void Init()
        {
            homeController = new HomeController();
        }

        public void InsertAlbum(Album album)
        {
            _albumRepository.InsertAlbum(album);
        }
    }
}
