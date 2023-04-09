using Core.Application.Features.Categories.Commands.CreateCategory;
using Core.Application.Features.Categories.Queries.GetCategoriesList;
using Core.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediatr.Send(new GetCategoriesListQuery());

            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> 
            GetCategoriesWithEvents(bool includeHistory)
        {
            var mediatrParams = new GetCategoriesListWithEventsQuery()
            { 
                IncludeHistory = includeHistory
            };

            var dtos = await _mediatr.Send(mediatrParams);

            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<List<CategoryEventListVm>>>
            AddCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediatr.Send(createCategoryCommand);

            return Ok(response);
        }

    }
}
