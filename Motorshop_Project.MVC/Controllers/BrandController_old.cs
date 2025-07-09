using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
    public class BrandController_old : Controller
    {
        private readonly IBrandLogic _logic;
        private readonly IMapper mapper;


        public BrandController_old(IBrandLogic logic, IMapper mapper)
        {
            _logic = logic;
            this.mapper = mapper;
        }

        // GET: BrandEntities
        public async Task<IActionResult> Index()
        {
            return View(await _logic.ReadAllAsync());
        }

        // GET: BrandEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandEntity = await _logic.ReadAsync(id.Value);
            if (brandEntity == null)
            {
                return NotFound();
            }

            return View(brandEntity);
        }

        // GET: BrandEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Alt,ImgUrl")] Brand brandEntity)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateAsync(brandEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(brandEntity);
        }

        // GET: BrandEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandEntity = await _logic.ReadAsync(id.Value);
            if (brandEntity == null)
            {
                return NotFound();
            }
            return View(brandEntity);
        }

        // POST: BrandEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Alt,ImgUrl")] Brand brandEntity)
        {
            if (id != brandEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _logic.Update(brandEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandEntityExists(brandEntity.Id))
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
            return View(brandEntity);
        }

        // GET: Brand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandEntity = await _logic.ReadAsync(id.Value);
            if (brandEntity == null)
            {
                return NotFound();
            }

            return View(brandEntity);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Brand brandEntity)
        {
            await _logic.DeleteAsync(brandEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool BrandEntityExists(int id)
        {
            return _logic.ReadAll().Any(e => e.Id == id);
        }
    }
}
