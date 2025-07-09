using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
    public class ExtrasController : Controller
    {
        private readonly IExtrasLogic _logic;

        public ExtrasController(IExtrasLogic logic)
        {
            _logic = logic;
        }

        // GET: Extras
        public async Task<IActionResult> Index()
        {
            return View(await _logic.ReadAllAsync());
        }

        // GET: Extras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _logic.ReadAsync(id.Value);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // GET: Extras/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name");
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,Name,Type,Price,Description")] Extras extra)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateAsync(extra);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", extra.ModelId);
            return View(extra);
        }

        // GET: Extras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _logic.ReadAsync(id.Value);
            if (extra == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", extra.ModelId);
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,Name,Type,Price,Description")] Extras extra)
        {
            if (id != extra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _logic.UpdateAsync(extra);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtrasEntityExists(extra.Id))
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
            ViewData["ModelId"] = new SelectList(_logic.GetModels, "Id", "Name", extra.ModelId);
            return View(extra);
        }

        // GET: Extras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _logic.ReadAsync(id.Value);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extra = await _logic.ReadAsync(id);
            if (extra != null)
            {
                await _logic.DeleteAsync(extra);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ExtrasEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
