using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motorshop_Project.MVC.ViewModels;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderLogic _logic;

        public OrdersController(IOrderLogic logic)
        {
            _logic = logic;
        }

        // GET: Orders

        public async Task<IActionResult> Index()
        {
            return View(await _logic.ReadAllAsync());
        }

        // GET: Orders/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _logic.ReadAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ExtraId"] = new MultiSelectList(_logic.GetExtras.Where(e => e.Id == id.Value), "Id", "Name");

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var brands = _logic.GetBrands;
            var models = _logic.GetModels;
            //ViewData["ExtraId"] = new MultiSelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            ViewData["BrandId"] = new SelectList(brands, "Id", "Name");
            ViewData["ModelId"] = new SelectList(models.Where(m => m.BrandId == brands.First().Id), "Id", "Name");
            ViewData["ExtraId"] = new MultiSelectList(_logic.GetExtras.Where(e => e.ModelId == models.First().Id), "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,BrandId,ModelId,OrderTime,HasExtras")] OrderVm orderVm)
        public async Task<IActionResult> Create([Bind("Order,SelectedExtraIds")] OrderVm orderVm)
        {
            if (ModelState.IsValid)
            {
                orderVm.Order.SelectedExtraIds = orderVm.SelectedExtraIds;
                if (orderVm.SelectedExtraIds.Count > 0)
                    orderVm.Order.HasExtras = true;

                await _logic.CreateAsync(orderVm.Order);

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", orderVm.Order.BrandId);
            ViewData["ModelId"] = new SelectList(_logic.GetModels.Where(m => m.BrandId == orderVm.Order.BrandId), "Id", "Name", orderVm.Order.ModelId);
            ViewData["ExtraId"] = new MultiSelectList( _logic.GetExtras.Where(e => e.ModelId == orderVm.Order.ModelId), "Id", "Name", orderVm.SelectedExtraIds );
            return View(orderVm);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _logic.ReadAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            var allExtras = _logic.GetExtras.Where(e => e.ModelId == order.ModelId);
            var orderVm= new OrderVm(order, order.Extras.Select(x => x.Id).ToList());

            ViewData["ExtraId"] = allExtras
                .Select(extra => new SelectListItem
                {
                    Text = extra.Name,
                    Value = extra.Id.ToString(),
                    Selected = orderVm.SelectedExtraIds.Contains(extra.Id)
                }).ToList();
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name");
            ViewData["ModelId"] = new SelectList(_logic.GetModels.Where(m => m.BrandId == order.BrandId), "Id", "Name");
            return View(orderVm);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,ModelId,OrderTime,HasExtras")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _logic.UpdateAsync(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEntityExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", order.BrandId);
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", order.ModelId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _logic.ReadAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var orderEntity = await _logic.ReadAsync(id);
            var orderEntity = await _logic.ReadAsNoTrackingAsync(id);
            if (orderEntity != null)
            {
                await _logic.DeleteAsync(orderEntity);
            }
            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult GetExtrasByModel(int modelId)
        {
            var extras = _logic.GetExtras
                               .Where(e => e.ModelId == modelId)
                               .Select(e => new { e.Id, e.Name })
                               .ToList();

            return Json(extras);
        }

        [HttpGet]
        public IActionResult GetModelsBybrand(int brandId)
        {
            var extras = _logic.GetModels
                               .Where(e => e.BrandId == brandId)
                               .Select(e => new { e.Id, e.Name })
                               .ToList();

            return Json(extras);
        }
        private bool OrderEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
