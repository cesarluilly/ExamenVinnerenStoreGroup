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
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;
        //--------------------------------------------------------------------------------------------------------------
        public ProductController(

            IProductApplication productApplication
            )
        {
            _productApplication = productApplication;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult Get(

            int intPk
            )
        {
            var response = _productApplication.subGet(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetByCategoryOrSubCategory(

            String strCategory,
            String strSubCategory
            )
        {
            var response = _productApplication.subGetByCategoryOrSubCategory(strCategory, strSubCategory);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetByRangeInventory(
            
            int intInitial, 
            int intEnd
            )
        {
            var response = _productApplication.GetByRangeInventory(intInitial, intEnd);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetAll(

            )
        {
            var response = _productApplication.subGetAll();

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Add(

            [FromBody] ProductDto productDto
            )
        {
            var response = _productApplication.subAdd(productDto);
            
            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPut("[action]")]
        public IActionResult Update(

            [FromBody] ProductDto productDto
            )
        {
            var response = _productApplication.subUpdate(productDto);

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
            var response = _productApplication.subDelete(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
