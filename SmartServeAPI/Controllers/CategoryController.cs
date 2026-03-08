using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Entities;
using SmartServe.Domain.Interfaces;
using SmartServe.Infrastructure.Authorization;
using SmartServe.Infrastructure.Logging;

namespace SmartServe.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryStore _store;
        private readonly ICurrentUser _currentUser;

        public CategoryController(
            IMapper mapper,
            ICategoryStore store,
            ICurrentUser currentUser)
        {
            _mapper = mapper;
            _store = store;
            _currentUser = currentUser;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new BaseResponseDto<CategoryDto>();

            var category = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (category == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = _mapper.Map<CategoryDto>(category);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new BaseResponseDto<List<CategoryDto>>();
            var categories = await _store.GetAllAsync(_currentUser.TenantId.Value);

            if (categories == null || categories.Count <= 0)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultCodes.RecordNotFound);
                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = _mapper.Map<List<CategoryDto>>(categories);
            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultCodes.Success);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(RoleType.Admin)]
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

        [HttpPost]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> Create(CategoryCreateRequestDto request)
        {
            var response = new BaseResponseDto<CategoryDto>();

            var category = _mapper.Map<Category>(request);
            category.TenantId = _currentUser.TenantId.Value;
            category.CreatedAt = DateTime.UtcNow;
            category.UpdatedAt = DateTime.UtcNow;

            await _store.AddAsync(category);
            await _store.SaveAsync();

            response.Data = _mapper.Map<CategoryDto>(category);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> Update(int id, CategoryUpdateRequestDto request)
        {
            var response = new BaseResponseDto<CategoryDto>();

            var category = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (category == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return BadRequest(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            _mapper.Map(request, category);
            category.UpdatedAt = DateTime.UtcNow;

            await _store.SaveAsync();

            response.Data = _mapper.Map<CategoryDto>(category);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }
    }
}
