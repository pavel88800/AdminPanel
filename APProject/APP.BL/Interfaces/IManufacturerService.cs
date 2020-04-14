﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.Models.Results;

namespace APP.BL.Interfaces
{
    interface IManufacturerService
    {
        /// <summary>
        ///     Получить все производителей.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetManufacturerAsync(int offset, int count);

        /// <summary>
        ///     Получить производителя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<OffsetEntitiesDto> GetManufacturerById(long id);

        /// <summary>
        ///     Создать производителя .
        /// </summary>
        /// <returns></returns>
        Task<Result> AddManufacturer();

        /// <summary>
        ///     Удалить производителя по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteManufacturer(List<long> ids);
    }
}
