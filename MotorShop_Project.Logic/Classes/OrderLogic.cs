using AutoMapper;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using MotorShop_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        public async Task CreateAsync(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            await unitOfWork.Orders.CreateAsync(entity);
            await unitOfWork.CompleteAsync();
        }
        public Order Read(int id)
        {
            var entity = unitOfWork.Orders.Read(id);
            return mapper.Map<Order>(entity);
        }

        public async Task<Order> ReadAsync(int id)
        {
            var entity = await unitOfWork.Orders.ReadAsync(id);
            return mapper.Map<Order>(entity);

        }
        public void Update(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Update(entity);
            unitOfWork.Complete();
        }

        public async Task UpdateAsync(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Update(entity);
            await unitOfWork.CompleteAsync();
        }

        public void Delete(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Delete(entity);
            unitOfWork.Complete();
        }
        public async Task DeleteAsync(Order item)
        {
            var entity = mapper.Map<OrderEntity>(item);
            unitOfWork.Orders.Delete(entity);
            await unitOfWork.CompleteAsync();
        }
        
        public IEnumerable<Order> ReadAll()
        {
            return mapper.Map<IEnumerable<Order>>(unitOfWork.Models.ReadAll());
        }
        

        public async Task<IEnumerable<Order>> ReadAllAsync()
        {
            return mapper.Map<IEnumerable<Order>>(await unitOfWork.Models.ReadAllAsync());
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
