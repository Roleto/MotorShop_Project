using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelLogic _logic;

        public ModelsController(IModelLogic logic)
        {
            _logic = logic;
        }


        // GET: ModelEntities
        public async Task<IActionResult> Index()
        {
            return View(await _logic.ReadAllAsync());
        }

        // GET: ModelEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _logic.ReadAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        // GET: ModelEntities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name");
            return View();
        }

        // POST: ModelEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,BrandId,Name,Type,Price")] BrandModel model)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", model.BrandId);
            return View(model);
        }

        // GET: ModelEntities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _logic.ReadAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", model.BrandId);
            return View(model);
        }

        // POST: ModelEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,Name,Type,Price")] BrandModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _logic.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelEntityExists(model.Id))
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
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", model.BrandId);
            return View(model);
        }

        // GET: ModelEntities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _logic.ReadAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: ModelEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _logic.ReadAsync(id);
            if (model != null)
            {
                await _logic.DeleteAsync(model);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
