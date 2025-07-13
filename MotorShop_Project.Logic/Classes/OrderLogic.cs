using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using MotorShop_Project.Repository.Interface;
using System.Collections;

namespace MotorShop_Project.Logic.Classes
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public IEnumerable<Brand> GetBrands => mapper.Map<IEnumerable<Brand>>(unitOfWork.Brands.ReadAll());
        public IEnumerable<BrandModel> GetModels => mapper.Map<IEnumerable<BrandModel>>(unitOfWork.Models.ReadAll());

        public IEnumerable<Extras> GetExtras => mapper.Map<IEnumerable<Extras>>(unitOfWork.Extras.ReadAll());

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
            var extraEntities = unitOfWork.Extras.ReadAll()
                                    .Where(e => item.SelectedExtraIds.Contains(e.Id))
                                    .ToList();

            entity.Extras = extraEntities;
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
        
        public IQueryable<Order> ReadAll()
        {
            return mapper.Map<IEnumerable<Order>>(unitOfWork.Orders.ReadAll()).AsQueryable();
        }
        

        public async Task<IEnumerable<Order>> ReadAllAsync()
        {
            return mapper.Map<IEnumerable<Order>>(await unitOfWork.Orders.ReadAllAsync());
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

        public async Task<Order> ReadAsNoTrackingAsync(int id)
        {
            return mapper.Map<Order>(await unitOfWork.Orders.ReadNoTracking(id));
        }
    }
}
