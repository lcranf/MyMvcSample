using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Common.Extensions
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectItems<T>(this IEnumerable<T> items, int selectedItem = -1)
            where T : BaseReferenceEntity
        {
            if (items.IsNullOrEmpty()) return Enumerable.Empty<SelectListItem>();

            //generate a display name
            var displayLabel = "Select " + typeof (T).Name.DisplayName();
            var displaySelectItem = new SelectListItem
                                        {
                                            Value = "-1",
                                            Text = displayLabel,
                                            Selected = (selectedItem == -1)
                                        };
            
            var selectList = items.Select(i => new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString(),
                                            Selected = i.Id.Equals(selectedItem)
                                        }).ToList();

            selectList.Add(displaySelectItem);

            return selectList;
        }
    }
}