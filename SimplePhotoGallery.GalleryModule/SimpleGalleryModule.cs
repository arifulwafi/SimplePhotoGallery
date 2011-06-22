using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using SimplePhotoGallery.Core;
using SimplePhotoGallery.Core.Configuration;
using SimplePhotoGallery.GalleryModule.Configuration;
using SimplePhotoGallery.GalleryModule.Util;
using SimplePhotoGallery.GalleryModule.Models;
using SimplePhotoGallery.GalleryModule.Services;
using SimplePhotoGallery.GalleryModule.Repositories;
using SimplePhotoGallery.GalleryModule.Repositories.Context;
using Autofac;


namespace SimplePhotoGallery
{
    public class SimpleGalleryModule : ModuleBase
    {
        public override void RegisterRoutes(RouteCollection routeCollection)
        {

        }

        public override void RegisterComponents(ContainerBuilder containerBuilder)
        {

            containerBuilder.Register(
                container => new RepositoryContext(container.Resolve<IConnectionString>()));

            containerBuilder.Register(
                container => new RepositoryContextInitializer(container.Resolve<RepositoryContext>())).As
                <IRepositoryContextInitializer>();

            containerBuilder.Register(
              container => new WebConfigConfiguration()).As
              <IGalleryModuleConfiguration>();


            containerBuilder.Register(container => new ImageUtility()).As<IImageUtility>();

            containerBuilder.Register(container => new PhotoService(container.Resolve<IPhotoRepository>(),container.Resolve<IImageUtility>(), container.Resolve<IGalleryModuleConfiguration>())).As<IPhotoService>();
            containerBuilder.Register(container => new AlbumService(container.Resolve<IAlbumRepository>())).As<IAlbumService>();

            containerBuilder.Register(container => new PhotoRepository(container.Resolve<RepositoryContext>())).As<IPhotoRepository>();
            containerBuilder.Register(container => new AlbumRepository(container.Resolve<RepositoryContext>())).As<IAlbumRepository>();
        }
    }
}
