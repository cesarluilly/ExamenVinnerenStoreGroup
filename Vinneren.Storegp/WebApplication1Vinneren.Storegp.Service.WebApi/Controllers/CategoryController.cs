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
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;
        //--------------------------------------------------------------------------------------------------------------
        public CategoryController(

            ICategoryApplication categoryApplication
            )
        {
            _categoryApplication = categoryApplication;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult Get(

            int intPk
            )
        {
            var response = _categoryApplication.subGet(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetAll(

            )
        {
            var response = _categoryApplication.subGetAll();

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Add(

            [FromBody] CategoryDto categoryDto
            )
        {
            var response = _categoryApplication.subAdd(categoryDto);
            
            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPut("[action]")]
        public IActionResult Update(

            [FromBody] CategoryDto categoryDto
            )
        {
            var response = _categoryApplication.subUpdate(categoryDto);

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
            var response = _categoryApplication.subDelete(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
