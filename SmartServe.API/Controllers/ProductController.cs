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
    [Route("api/products")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductStore _store;
        private readonly ICurrentUser _currentUser;

        public ProductController(
            IMapper mapper,
            IProductStore store,
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
            var response = new BaseResponseDto<ProductDto>();

            var product = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (product == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = _mapper.Map<ProductDto>(product);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new BaseResponseDto<List<ProductDto>>();

            var products = await _store.GetAllAsync(_currentUser.TenantId.Value);

            if (products == null || products.Count == 0)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = _mapper.Map<List<ProductDto>>(products);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> Create(CreateProductRequestDto request)
        {
            var response = new BaseResponseDto<ProductDto>();

            var product = _mapper.Map<Product>(request);

            product.TenantId = _currentUser.TenantId.Value;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            _store.Add(product);
            await _store.SaveAsync();

            response.Data = _mapper.Map<ProductDto>(product);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> Update(int id, UpdateProductRequestDto request)
        {
            var response = new BaseResponseDto<ProductDto>();

            var product = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (product == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return BadRequest(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            _mapper.Map(request, product);
            product.UpdatedAt = DateTime.UtcNow;

            _store.Update(product);
            await _store.SaveAsync();

            response.Data = _mapper.Map<ProductDto>(product);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(RoleType.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BaseResponseDto<BlankDto>();

            var product = await _store.GetByIdAsync(_currentUser.TenantId.Value, id);

            if (product == null)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return BadRequest(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            product.IsDeleted = true;
            product.UpdatedAt = DateTime.UtcNow;

            _store.Update(product);
            await _store.SaveAsync();

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpPost]
        [Route("bulk/update")]
        [Authorize(RoleType.Admin, RoleType.Manager)]
        public async Task<IActionResult> BulkUpdate(List<BulkUpdateProductRequestDto> request)
        {
            var response = new BaseResponseDto<BlankDto>();

            var products = _mapper.Map<List<Product>>(request);

            foreach (var product in products)
            {
                if (product.Id == 0)
                {
                    product.TenantId = _currentUser.TenantId.Value;
                    product.CreatedAt = DateTime.UtcNow;
                    product.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    product.UpdatedAt = DateTime.UtcNow;
                }
            }

            await _store.SaveBulkAsync(products);

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }
    }
}