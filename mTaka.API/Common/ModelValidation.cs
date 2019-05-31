using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;

namespace mTaka.API.Common
{
    public class ModelValidation : ApiController //using System.Web.Http;
    {
        public static bool TryValidateModel(object model, out string _modelError)
        {
            ModelValidation _ObjModelValidation = new ModelValidation();
            return _ObjModelValidation.TryValidateModel(model, null /* prefix */, out _modelError);
        }

        protected internal bool TryValidateModel(object model, string prefix, out string _modelError)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType());    //using System.Web.ModelBinding;
            var t = new ModelBindingExecutionContext(new HttpContextWrapper(HttpContext.Current), new System.Web.ModelBinding.ModelStateDictionary());  //using System.Web;

            foreach (ModelValidationResult validationResult in ModelValidator.GetModelValidator(metadata, t).Validate(null))
            {
                ModelState.AddModelError(validationResult.MemberName, validationResult.Message);
            }

            _modelError = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
            return ModelState.IsValid;
        }
    }
}