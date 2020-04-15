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

namespace APP.BL.Services
{
    /// <summary>
    ///     Сервис по работе с производителями.
    /// </summary>
    public class ManufacturerService : AbstractGetService<Manufacturer>, IManufacturerService
    {
        /// <summary>
        ///     Контекст БД.
        /// </summary>
        private readonly PanelContext _context;

        public ManufacturerService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetManufacturerAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetManufacturerById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddManufacturer(ManufacturerDto manufacturerDto)
        {
            var manufacturer = new Manufacturer
            {
                Name = manufacturerDto.Name,
                Sort = manufacturerDto.Sort,
                Status = manufacturerDto.Status
            };
            await _context.AddAsync(manufacturer);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }

        /// <inheritdoc />
        public Result DeleteManufacturer(List<long> ids)
        {
            try
            {
                DeleteItems(ids);
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        /// <inheritdoc />
        public Result UpdateManufucturer(ManufacturerDto manufacturerDto)
        {
            try
            {
                var manufacturer = _context.Manufacturers.Find(manufacturerDto.Id);

                manufacturer.Name = manufacturerDto.Name;
                manufacturer.Sort = manufacturerDto.Sort;
                manufacturer.Status = manufacturerDto.Status;

                _context.Update(manufacturer);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}