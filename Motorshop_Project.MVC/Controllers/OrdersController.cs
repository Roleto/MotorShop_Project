using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
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
            var ordersSet = _logic.ReadAll().Include(o => o.Brand).Include(o => o.Model);
            return View(await ordersSet.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntity = await _logic.ReadAll()
                .Include(o => o.Brand)
                .Include(o => o.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return View(orderEntity);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name");
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandId,ModelId,OrderTime,HasExtras")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateAsync(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", order.BrandId);
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", order.ModelId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntity = await _logic.ReadAsync(id.Value);
            if (orderEntity == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", orderEntity.BrandId);
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", orderEntity.ModelId);
            return View(orderEntity);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            var orderEntity = await _logic.ReadAll()
                .Include(o => o.Brand)
                .Include(o => o.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return View(orderEntity);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderEntity = await _logic.ReadAsync(id);
            if (orderEntity != null)
            {
                await _logic.DeleteAsync(orderEntity);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool OrderEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
