using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APP.DB;
using APP.DB.Models;
using APP.Models.Results;

namespace APP.BL.Services
{
    /// <summary>
    ///     Сервис по работе с покупателями.
    /// </summary>
    public class CustomerService : AbstractGetService<Customer>, ICustomerService
    {
        /// <summary>
        ///     Контекст БД.
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public CustomerService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetCustomerAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetCustomerById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddCustomer(CustomerDto customerDto)
        {
            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                var customer = new Customer
                {
                    Address = customerDto.Address,
                    City = customerDto.City,
                    Company = customerDto.Company,
                    Country = customerDto.Country,
                    Email = customerDto.Email,
                    Faxs = customerDto.Faxs,
                    Ip = customerDto.Ip,
                    LastName = customerDto.LastName,
                    Name = customerDto.Name,
                    Phone = customerDto.Phone,
                    Region = customerDto.Region,
                    Sort = customerDto.Sort,
                    Status = customerDto.Status,
                    Zip = customerDto.Zip
                };

                await _context.AddAsync(customer);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Result DeleteCustomer(List<long> ids)
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
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Result UpdateCustomer(CustomerDto customerDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var customer = _context.Customers.Find(customerDto.Id);

                customer.Address = customerDto.Address;
                customer.City = customerDto.City;
                customer.Company = customerDto.Company;
                customer.Country = customerDto.Country;
                customer.Email = customerDto.Email;
                customer.Faxs = customerDto.Faxs;
                customer.Ip = customerDto.Ip;
                customer.LastName = customerDto.LastName;
                customer.Name = customerDto.Name;
                customer.Phone = customerDto.Phone;
                customer.Region = customerDto.Region;
                customer.Sort = customerDto.Sort;
                customer.Status = customerDto.Status;
                customer.Zip = customerDto.Zip;

                _context.Update(customer);
                _context.SaveChanges();
                transaction.Commit();

                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }
    }
}