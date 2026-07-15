using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartServe.API.Helper;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.Domain.Stores;
using SmartServe.EFCore.Models;

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

            var category = await _store.GetByIdAsync(id);

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
            var categories = await _store.GetAllAsync();

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
            var response = new BaseResponseDto<BlankDto>();
            var category = await _store.GetByIdAsync(id);

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
        public async Task<IActionResult> Create(CreateCategoryRequestDto request)
        {
            var response = new BaseResponseDto<CategoryDto>();

            var category = _mapper.Map<CategoryEntity>(request);
            
            _store.Add(category);
            await _store.SaveAsync();

            response.Data = _mapper.Map<CategoryDto>(category);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> Update(int id, UpdateCategoryRequestDto request)
        {
            var response = new BaseResponseDto<CategoryDto>();

            var category = await _store.GetByIdAsync(id);

            if (category == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return BadRequest(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            _mapper.Map(request, category);
            
            _store.Update(category);
            await _store.SaveAsync();

            response.Data = _mapper.Map<CategoryDto>(category);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPost]
        [Route("bulk/update")]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> BulkUpdate(List<BulkUpdateCategoryRequestDto> request)
        {
            var response = new BaseResponseDto<BlankDto>();

            var categories = _mapper.Map<List<CategoryEntity>>(request);
            await _store.SaveBulkAsync(categories);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }
    }
}
