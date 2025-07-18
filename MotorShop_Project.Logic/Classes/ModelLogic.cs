﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using MotorShop_Project.Repository.Interface;

namespace MotorShop_Project.Logic.Classes
{
    public class ModelLogic : IModelLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public IEnumerable<Brand> GetBrands => mapper.Map<IEnumerable<Brand>>(unitOfWork.Brands.ReadAll());

        public ModelLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Create(entity);
            unitOfWork.Complete();
        }
        public async Task CreateAsync(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            await unitOfWork.Models.CreateAsync(entity);
            await unitOfWork.CompleteAsync();
        }
        public async Task CreateAsync(ModelEntity item)
        {
            await unitOfWork.Models.CreateAsync(item);
            await unitOfWork.CompleteAsync();
        }

        public BrandModel Read(int id)
        {
            var entity = unitOfWork.Brands.Read(id);
            return mapper.Map<BrandModel>(entity);
        }

        public async Task<BrandModel> ReadAsync(int id)
        {
            var entity = await unitOfWork.Brands.ReadAsync(id);
            return mapper.Map<BrandModel>(entity);
        }
        public void Update(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Update(entity);
            unitOfWork.Complete();
        }

        public async Task UpdateAsync(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Update(entity);
            await unitOfWork.CompleteAsync();
        }
        public void Delete(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Delete(entity);
            unitOfWork.Complete();
        }

        public async Task DeleteAsync(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Delete(entity);
            await unitOfWork.CompleteAsync();
        }
        public IQueryable<BrandModel> ReadAll()
        {
            return mapper.Map<IEnumerable<BrandModel>>(unitOfWork.Models.ReadAll()).AsQueryable();
        }
        public async Task<IEnumerable<BrandModel>> ReadAllAsync()
        {
            return mapper.Map<IEnumerable<BrandModel>>( await unitOfWork.Models.ReadAllAsync());

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
