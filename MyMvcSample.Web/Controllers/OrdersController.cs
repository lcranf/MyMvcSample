using System.Web.Mvc;
using MyMvcSample.Common.Extensions;
using MyMvcSample.Common.Mvc;
using MyMvcSample.Core.Services;
using MyMvcSample.Domain.Entities;
using MyMvcSample.ViewModels;

namespace MyMvcSample.Controllers
{   
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //
        // GET: /Orders/

        public ViewResult Index()
        {
            return View(_orderService.FindAll().MapListTo(new OrderViewModel()));
        }

        //
        // GET: /Orders/Details/5

        public ViewResult Details(Order id)
        {
            return View(id.MapTo(new OrderViewModel()));
        }

        //
        // GET: /Orders/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Orders/Create

        [HttpPost]
        public ActionResult Create(OrderCreateModel model)
        {
            if (ModelState.IsValid) 
            {
                _orderService.CreateFromModel(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        //
        // GET: /Orders/Edit/5
 
        public ActionResult Edit(Order id)
        {
            //if meta data is needed then we'd either call IOrderServer
            //or rely on some IMetadataService to get data (ie, IOrderTypeService)

             return View(id.MapTo(new OrderEditModel()));
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _orderService.UpdateFromModel(model);
                
            return RedirectToAction("Index");
        }

        //
        // GET: /Orders/Delete/5
 
        public ActionResult Delete(Order id)
        {
            return View(id);
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _orderService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

