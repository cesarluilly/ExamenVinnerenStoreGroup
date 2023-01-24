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
        private readonly ICategoryApplication _categoryDomain;
        //--------------------------------------------------------------------------------------------------------------
        public CategoryController(

            ICategoryApplication categoryDomain
            )
        {
            _categoryDomain = categoryDomain;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Add(

            [FromBody] CategoryDto categoryDto
            )
        {
            var response = _categoryDomain.subAdd(categoryDto);
            
            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Update(

            [FromBody] CategoryDto categoryDto
            )
        {
            var response = _categoryDomain.subUpdate(categoryDto);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult Get(

            int intPk
            )
        {
            var response = _categoryDomain.subGet(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult GetAll(

            )
        {
            var response = _categoryDomain.subGetAll();

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpGet("[action]")]
        public IActionResult Remove(

            int intPk
            )
        {
            var response = _categoryDomain.subRemove(intPk);

            if (response.intStatus == 200)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
