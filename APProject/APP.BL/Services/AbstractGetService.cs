using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.DB;
using APP.DB.Models;
using APP.Models.BaseModelsEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace APP.BL.Services
{
    /// <summary>
    ///     Абстрактный класс для получения элементов согласно пагинации.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractGetService<T> where T : BaseIdEntity
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Множество.
        /// </summary>
        private readonly DbSet<T> _set;

        protected AbstractGetService(PanelContext context)
        {
            _set = context.Set<T>();
            _context = context;
        }

        /// <summary>
        ///     Получить статьи согласно пагинации.
        /// </summary>
        /// <param name="offset">Страница.</param>
        /// <param name="count">Количество на странице.</param>
        /// <returns></returns>
        protected async Task<OffsetEntitiesDto> GetPagesAsync(int offset, int count)
        {
            var totalCount = await _set.CountAsync();

            if (totalCount == 0) return new OffsetEntitiesDto();

            var entities = _set.Skip(offset).Take(count).ToListAsync();

            return new OffsetEntitiesDto { Entities = await entities, TotalCount = totalCount };
        }

        /// <summary>
        ///     Получить Элемент по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        protected async Task<T> GetItemById(long id)
        {
            return await _set.FindAsync(id);
        }

        /// <summary>
        ///     Удалить Выбранные элементы.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        protected bool DeleteItems(IEnumerable<long> ids)
        {
            try
            {
                _set.RemoveRange(_set.Where(x => ids.Contains(x.Id)));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        ///     Получить файл.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected async Task<Picture> GetFile(IFormFile file)
        {
            if (file != null && file.Length > 0) 
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var array = memoryStream.ToArray();

                var picture = new Picture
                {
                    Name = file.FileName,
                    Sort = 0,
                    Status = true,
                    Images = array
                };
                return picture;
            }
            return null;
        }
    }
}