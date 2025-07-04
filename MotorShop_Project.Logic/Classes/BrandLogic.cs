using AutoMapper;
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

        public Brand Read(int id)
        {
            var entity = unitOfWork.Brands.Read(id);
            return mapper.Map<Brand>(entity);
        }

        public void Update(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Update(entity);
            unitOfWork.Complete();
        }
        public void Delete(Brand item)
        {
            var entity = mapper.Map<BrandEntity>(item);
            unitOfWork.Brands.Delete(entity);
            unitOfWork.Complete();
        }
        public IEnumerable<Brand> ReadAll()
        {
            return mapper.Map<IEnumerable<Brand>>(unitOfWork.Brands.ReadAll());
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
