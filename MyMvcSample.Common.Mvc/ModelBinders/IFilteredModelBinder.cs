using System;
using System.Web.Mvc;

namespace MyMvcSample.Common.Mvc.ModelBinders
{
    public interface IFilteredModelBinder : IModelBinder
    {
        bool IsMatch(Type modelType);
    }
}