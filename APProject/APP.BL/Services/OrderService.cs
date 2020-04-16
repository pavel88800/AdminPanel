namespace APP.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Сервис по работе с заказами.
    /// </summary>
    public class OrderService : AbstractGetService<Order>, IOrderService
    {
        private readonly PanelContext _context;

        public OrderService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetOrderAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetOrderById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddOrder(OrderDto orderDto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var customer = await _context.Customers.FindAsync(orderDto.CustomerId);
                var productsQuery =
                    await _context.Products.Where(x => orderDto.ProductsId.Contains(x.Id)).ToListAsync();
                var order = new Order
                {
                    Customer = customer ?? null,
                    Sum = orderDto.Sum,
                    TimeAdd = orderDto.TimeAdd,
                    TimeUpdate = orderDto.TimeUpdate
                };
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                if (productsQuery.Count > 0)
                {
                    var products = productsQuery.Select(x => new OrderProduct
                        {OrderId = order.Id, Order = order, Product = x, ProductId = x.Id});

                    await _context.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Result DeleteOrder(List<long> ids)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                DeleteItems(ids);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <inheritdoc />
        public Result UpdateOrder(OrderDto orderDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var customer = _context.Customers.Find(orderDto.CustomerId);
                var productsQueryNew =
                    _context.Products.Where(x => orderDto.ProductsId.Contains(x.Id)).ToList();
                var order = _context.Orders.Include(x => x.Products).FirstOrDefault(x => x.Id == orderDto.Id);

                if (order != null)
                {
                    order.Customer = customer ?? null;
                    order.Sum = orderDto.Sum;
                    order.TimeAdd = orderDto.TimeAdd;
                    order.TimeUpdate = orderDto.TimeUpdate;

                    _context.Update(order);
                    _context.SaveChanges();

                    if (productsQueryNew.Count > 0)
                    {
                        var oldProduct = order.Products;
                        if (oldProduct.Count > 0)
                            _context.RemoveRange(oldProduct);

                        var products = productsQueryNew.Select(x => new OrderProduct
                            {OrderId = order.Id, Order = order, Product = x, ProductId = x.Id});

                        _context.AddRange(products);
                        _context.SaveChanges();
                    }

                    transaction.Commit();
                    return Result.Ok();
                }

                return Result.Fail("Обновление не увенчалось успехом.");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }
    }
}