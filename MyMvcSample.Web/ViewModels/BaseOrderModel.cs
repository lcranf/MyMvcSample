using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyMvcSample.ViewModels
{
    public abstract class BaseOrderModel : BaseAuditableModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int OrderStatusId { get; set; }

        public DateTime? OrderDate { get; set; }

        //reference types
        public IEnumerable<SelectListItem> OrderStatuses { get; set; }
    }
}