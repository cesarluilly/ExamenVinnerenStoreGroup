using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vinneren.Storegp.Application.Interface;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Transversal.Mapper;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 22, 2023. 
namespace WebApplication1Vinneren.Storegp.Service.WebApi.Controllers
{
    //==================================================================================================================
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryApplication _inventoryApplication;
        //--------------------------------------------------------------------------------------------------------------
        public InventoryController(

            IInventoryApplication inventoryApplication
            )
        {
            _inventoryApplication = inventoryApplication;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult Get(

            int intPk
            )
        {
            var response = _inventoryApplication.subGet(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetAll(

            )
        {
            var response = _inventoryApplication.subGetAll();

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Add(

            [FromBody] InventoryDto inventoryDto
            )
        {
            var response = _inventoryApplication.subAdd(inventoryDto);
            
            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPut("[action]")]
        public IActionResult Update(

            [FromBody] InventoryDto inventoryDto
            )
        {
            var response = _inventoryApplication.subUpdate(inventoryDto);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpDelete("[action]")]
        public IActionResult Delete(

            int intPk
            )
        {
            var response = _inventoryApplication.subDelete(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
