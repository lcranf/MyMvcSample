using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcSample.ViewModels
{
    public abstract class BaseOrderModel : BaseAuditableModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}