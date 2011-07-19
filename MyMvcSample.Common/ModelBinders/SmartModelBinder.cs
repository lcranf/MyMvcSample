using System.Collections.Generic;
using System.Web.Mvc;

namespace MyMvcSample.Common.ModelBinders
{
    public class SmartModelBinder : DefaultModelBinder
    {
        private readonly IEnumerable<IFilteredModelBinder> _filteredModelBinders;

        public SmartModelBinder(IEnumerable<IFilteredModelBinder> filteredModelBinders)
        {
            _filteredModelBinders = filteredModelBinders;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            foreach (var modelBinder in _filteredModelBinders)
            {
                if (modelBinder.IsMatch(bindingContext.ModelType))
                {
                    return modelBinder.BindModel(controllerContext, bindingContext);
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
