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
        public Extras Read(int id)
        {
            var entity = unitOfWork.Extras.Read(id);
            return mapper.Map<Extras>(entity);
        }
        public void Update(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Update(entity);
            unitOfWork.Complete();
        }
        public void Delete(Extras item)
        {
            var entity = mapper.Map<ExtrasEntity>(item);
            unitOfWork.Extras.Delete(entity);
            unitOfWork.Complete();
        }
        public IEnumerable<Extras> ReadAll()
        {
            return mapper.Map<IEnumerable<Extras>>(unitOfWork.Extras.ReadAll());
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
