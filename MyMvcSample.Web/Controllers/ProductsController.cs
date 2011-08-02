using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcSample.Domain.Entities;
using MyMvcSample.Core.Services;
using MyMvcSample.Common.Mvc;
using MyMvcSample.ViewModels.Products;
using MyMvcSample.Common.Extensions;


namespace MyMvcSample.Controllers
{   
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        //
        // GET: /Products/

        public ViewResult Index()
        {
            return View(_productService.FindAll());
        }

        //
        // GET: /Products/Details/5

        public ViewResult Details(Product id)
        {
            return View(id);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            var model = new ProductCreateModel();
            return View(model);
        } 

        //
        // POST: /Products/Create
       
        [HttpPost]
        public ActionResult Create(ProductCreateModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateFromModel(product);
                
                return RedirectToAction("Index");
            }
            
            return View();
            
        }
        
        //
        // GET: /Products/Edit/5
 
        public ActionResult Edit(Product id)
        {
             var model = id.MapTo(new ProductCreateModel());
             return View(model);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPosted(ProductEditModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);                
            }
            
            _productService.UpdateFromModel(product);
            return RedirectToAction("Index");
        }

        //
        // GET: /Products/Delete/5
 
        public ActionResult Delete(Product id)
        {
            return View(id);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

