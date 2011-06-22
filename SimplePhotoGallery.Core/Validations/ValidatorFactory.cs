using System;
using System.Web.Mvc;
using FluentValidation;
namespace SimplePhotoGallery.Core.Validations
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = DependencyResolver.Current.GetService(validatorType) as IValidator;
            return validator;
        }
    }
}
