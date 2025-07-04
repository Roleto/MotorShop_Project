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
    public class ModelLogic : IModelLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

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
        public BrandModel Read(int id)
        {
            var entity = unitOfWork.Brands.Read(id);
            return mapper.Map<BrandModel>(entity);
        }

        public void Update(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Update(entity);
            unitOfWork.Complete();
        }
        public void Delete(BrandModel item)
        {
            var entity = mapper.Map<ModelEntity>(item);
            unitOfWork.Models.Delete(entity);
            unitOfWork.Complete();
        }
        public IEnumerable<BrandModel> ReadAll()
        {
            return mapper.Map<IEnumerable<BrandModel>>(unitOfWork.Models.ReadAll());
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
