using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace SimplePhotoGallery.Core.ModelBinders
{
   [ModelBinderType(typeof(Guid))]
   public class GuidModelBinder:IModelBinder
   {
       #region IModelBinder Members
       public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return valueProviderResult == null ? Guid.Empty : valueProviderResult.AttemptedValue.ToGuid();
        }
       #endregion IModelBinder Members
   }
}
