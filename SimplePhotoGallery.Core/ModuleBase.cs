using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace SimplePhotoGallery.Core
{
    public abstract class ModuleBase
    {
        public virtual void RegisterComponents(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterModelBinders(Assembly.GetExecutingAssembly());
        }

        public virtual void RegisterRoutes(RouteCollection routeCollection) { }
    }
}
