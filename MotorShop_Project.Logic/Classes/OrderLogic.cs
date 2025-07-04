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
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Create(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Create(entity);
            unitOfWork.Complete();
        }

        public Order Read(int id)
        {
            var entity = unitOfWork.Orders.Read(id);
            return mapper.Map<Order>(entity);
        }
        
        public void Update(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Update(entity);
            unitOfWork.Complete();
        }
        
        public void Delete(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Delete(entity);
            unitOfWork.Complete();
        }
        
        public IEnumerable<Order> ReadAll()
        {
            return mapper.Map<IEnumerable<Order>>(unitOfWork.Models.ReadAll());
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
