using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Repository.Classes
{
    public class BrandRepository : IRepository<BrandEntity>
    {
        private MotorShopDbContext context;

        public BrandRepository(MotorShopDbContext context)
        {
            this.context = context;
        }

        public void Create(BrandEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Brands.Add(item);
            context.SaveChanges();
        }
        public BrandEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Brand found with Id {id}");

            return readItem;
        }
        public void Update(BrandEntity item)
        {
                var oldItem = Read(item.Id);

                oldItem.Name = item.Name;
                oldItem.Models = item.Models;
                oldItem.Alt = item.Alt;
                oldItem.ImgUrl = item.ImgUrl;

                context.SaveChanges();
        }

        public void Delete(BrandEntity item)
        {
            context.Brands.Remove(item);
            context.SaveChanges();
        }
        
        public IEnumerable<BrandEntity> ReadAll()
        {
            return context.Set<BrandEntity>();
        }

        // Nem kell ehez a projecthez csak hogy ne feljds el hogy van ilyen is
        //public IEnumerable<BrandEntity> ReadAllNoTracking()
        //{
        //    return context.Set<BrandEntity>().AsNoTracking();
        //}
    }
}
