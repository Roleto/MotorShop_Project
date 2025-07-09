using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
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

            var modelEntity = await _logic.ReadAsync(id.Value);
            if (modelEntity == null)
            {
                return NotFound();
            }

            return View(modelEntity);
        }

        // GET: ModelEntities/Create
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
        public async Task<IActionResult> Create([Bind("Id,BrandId,Name,Type,Price")] BrandModel modelEntity)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateAsync(modelEntity);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", modelEntity.BrandId);
            return View(modelEntity);
        }

        // GET: ModelEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEntity = await _logic.ReadAsync(id.Value);
            if (modelEntity == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", modelEntity.BrandId);
            return View(modelEntity);
        }

        // POST: ModelEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,Name,Type,Price")] BrandModel modelEntity)
        {
            if (id != modelEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _logic.UpdateAsync(modelEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelEntityExists(modelEntity.Id))
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
            ViewData["BrandId"] = new SelectList(_logic.GetBrands, "Id", "Name", modelEntity.BrandId);
            return View(modelEntity);
        }

        // GET: ModelEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEntity = await _logic.ReadAll()
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelEntity == null)
            {
                return NotFound();
            }

            return View(modelEntity);
        }

        // POST: ModelEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelEntity = await _logic.ReadAsync(id);
            if (modelEntity != null)
            {
                await _logic.DeleteAsync(modelEntity);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
