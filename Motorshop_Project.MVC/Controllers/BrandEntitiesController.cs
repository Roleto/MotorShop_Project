//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MotorShop_Project.Data.DBContext;
//using MotorShop_Project.Data.Entities;
//using MotorShop_Project.Logic.Interfaces;

//namespace Motorshop_Project.MVC.Controllers
//{
//    public class BrandEntitiesController : Controller
//    {
//        //private readonly MotorShopDbContext _context;
//        private readonly IBrandLogic _logic;

//        public BrandEntitiesController(IBrandLogic logic)
//        {
//            _logic = logic;
//        }

//        // GET: BrandEntities
//        public async Task<IActionResult> Index()
//        {
//            return View(_logic.ReadAll());
//        }

//        // GET: BrandEntities/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var brandEntity = await _context.Brands
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (brandEntity == null)
//            {
//                return NotFound();
//            }

//            return View(brandEntity);
//        }

//        // GET: BrandEntities/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: BrandEntities/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Alt,ImgUrl")] BrandEntity brandEntity)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(brandEntity);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(brandEntity);
//        }

//        // GET: BrandEntities/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var brandEntity = await _context.Brands.FindAsync(id);
//            if (brandEntity == null)
//            {
//                return NotFound();
//            }
//            return View(brandEntity);
//        }

//        // POST: BrandEntities/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Alt,ImgUrl")] BrandEntity brandEntity)
//        {
//            if (id != brandEntity.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(brandEntity);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BrandEntityExists(brandEntity.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(brandEntity);
//        }

//        // GET: BrandEntities/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var brandEntity = await _context.Brands
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (brandEntity == null)
//            {
//                return NotFound();
//            }

//            return View(brandEntity);
//        }

//        // POST: BrandEntities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var brandEntity = await _context.Brands.FindAsync(id);
//            if (brandEntity != null)
//            {
//                _context.Brands.Remove(brandEntity);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool BrandEntityExists(int id)
//        {
//            return _context.Brands.Any(e => e.Id == id);
//        }
//    }
//}
