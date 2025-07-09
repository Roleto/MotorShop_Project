using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using MotorShop_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Logic.Classes
{
    public class ExtrasLogic : IExtrasLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExtrasLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Create(entity);
            unitOfWork.Complete();
        }
        public async Task CreateAsync(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            await unitOfWork.Extras.CreateAsync(entity);
            await unitOfWork.CompleteAsync();
        }
        public Extras Read(int id)
        {
            var entity = unitOfWork.Extras.Read(id);
            return mapper.Map<Extras>(entity);
        }
        public async Task<Extras> ReadAsync(int id)
        {
            var entity = await unitOfWork.Extras.ReadAsync(id);
            return mapper.Map<Extras>(entity);
        }


        public void Update(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Update(entity);
            unitOfWork.Complete();
        }
        public async Task UpdateAsync(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Update(entity);
            await unitOfWork.CompleteAsync();
        }
        public void Delete(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Delete(entity);
            unitOfWork.Complete();
        }
        public async Task DeleteAsync(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Delete(entity);
            await unitOfWork.CompleteAsync();
        }
        public DbSet<Extras> ReadAll()
        {
            return mapper.Map<DbSet<Extras>>(unitOfWork.Extras.ReadAll());
        }
        public async  Task<IEnumerable<Extras>> ReadAllAsync()
        {
            return mapper.Map<IEnumerable<Extras>>( await unitOfWork.Extras.ReadAllAsync());
        }
        public void nonCrud1()
        {
            throw new NotImplementedException();
        }

        public void nonCrud2()
        {
            throw new NotImplementedException();
        }

        public void nonCrud3()
        {
            throw new NotImplementedException();
        }
        
    }
}
