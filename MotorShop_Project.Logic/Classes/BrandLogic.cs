﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using MotorShop_Project.Repository.Interface;

namespace MotorShop_Project.Logic.Classes
{
    public class BrandLogic : IBrandLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BrandLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Create(entity);
            unitOfWork.Complete();
        }
        public async Task CreateAsync(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            await unitOfWork.Brands.CreateAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task CreateAsync(BrandEntity item)
        {
            await unitOfWork.Brands.CreateAsync(item);
            await unitOfWork.CompleteAsync();
        }
        public Brand Read(int id)
        {
            var entity = unitOfWork.Brands.Read(id);
            return mapper.Map<Brand>(entity);
        }

        public async Task<Brand> ReadAsync(int id)
        {
            var entity = await unitOfWork.Brands.ReadAsync(id);
            return mapper.Map<Brand>(entity);
        }
        public void Update(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Update(entity);
            unitOfWork.Complete();
        }

        public async Task UpdateAsync(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Update(entity);
            await unitOfWork.CompleteAsync();
        }
        public void Delete(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Delete(entity);
            unitOfWork.Complete();
        }

        public async Task DeleteAsync(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Delete(entity);
            await unitOfWork.CompleteAsync();
        }
        public IQueryable<Brand> ReadAll()
        {
            return mapper.Map<IEnumerable<Brand>>(unitOfWork.Brands.ReadAll()).AsQueryable();
        }
        public async Task<IEnumerable<Brand>> ReadAllAsync()
        {
            return mapper.Map<IEnumerable<Brand>>( await unitOfWork.Brands.ReadAllAsync());
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
