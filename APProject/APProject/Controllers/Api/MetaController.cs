using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APProject.Controllers.Api
{
    public class MetaController : BaseApiController
    {
        private readonly IMetaService _metaService;
        public MetaController(IConfiguration configuration, IMetaService metaService)
        {
            _metaService = metaService;
        }

        [HttpGet("/meta-menu")]
        public IActionResult GetMenuMeta()
        {
            var result = _metaService.GetMetaMenu();
            return Ok(result);
        }

        [HttpGet("/meta-info")]
        public IActionResult GetMetaInformation()
        {
            var result = _metaService.GetMetaInformation();
            return Ok(result);
        }
    }
}
