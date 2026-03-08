using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Interfaces;
using SmartServe.Infrastructure.Logging;

namespace SmartServe.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryStore _store;
        private readonly ICurrentUser _currentUser;

        public CategoryController(
        ICategoryStore store,
        ICurrentUser currentUser)
        {
            _store = store;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _store.GetAllAsync(_currentUser.TenantId.Value);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultCodes.Success);

            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BaseResponseDto<BlankClass>();
            var category = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (category == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultCodes.RecordNotFound);
                return BadRequest(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            _store.Remove(category);
            await _store.SaveAsync();

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultCodes.Success);

            return Ok(response);
        }
    }
}
