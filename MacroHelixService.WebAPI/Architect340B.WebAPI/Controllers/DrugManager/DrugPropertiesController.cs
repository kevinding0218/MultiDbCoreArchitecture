using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Architect340B.Services.Contracts;
using Architect340B.WebAPI.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Architect340B.WebAPI.Controllers.DrugManager
{
    [EnableCors("EnableCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class DrugPropertiesController : ControllerBase
    {
        private readonly IDrugPropertiesService _drugPropertiesService;

        public DrugPropertiesController(IDrugPropertiesService drugPropertiesService)
        {
            this._drugPropertiesService = drugPropertiesService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">If list returns successfully</response>
        /// <response code="401">If client is not authenticated</response>
        /// <response code="403">If client is not autorized</response>
        /// <response code="404">If list is not exists</response>
        /// <response code="500">If there was an internal error</response>
        [HttpGet("listDrugProperties")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ListDrugPropertiesAsync()
        {
            // Get response from business logic
            var response = await this._drugPropertiesService.GetListDrugPropertiesAsync();

            // Return as http response
            return response.ToHttpResponse();
        }
    }
}