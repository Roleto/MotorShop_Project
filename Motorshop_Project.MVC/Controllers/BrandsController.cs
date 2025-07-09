using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandLogic _logic;

        public BrandsController(IBrandLogic logic)
        {
            _logic = logic;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            return View(await _logic.ReadAllAsync());
        }

        // GET: Brands/Details/5
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

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Alt,Image,ContentType")] Brand brand, IFormFile? ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null && ImageUpload.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await ImageUpload.CopyToAsync(ms);
                        brand.Image = ms.ToArray();
                        brand.ContentType = ImageUpload.ContentType;
                    }
                }
                await _logic.CreateAsync(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _logic.ReadAsync(id.Value);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Alt,Image,ContentType")] Brand brand, IFormFile? ImageUpload, bool wantNewImage)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (wantNewImage)
                {
                    if (ImageUpload != null && ImageUpload.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await ImageUpload.CopyToAsync(ms);
                            brand.Image = ms.ToArray();
                            brand.ContentType = ImageUpload.ContentType;
                        }
                    }
                    else
                    {
                        brand.Image = null;
                        brand.ContentType = null;
                    }
                }
                try
                {
                    _logic.Update(brand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandEntityExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _logic.ReadAsync(id.Value);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
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
