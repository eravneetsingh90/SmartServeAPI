using Microsoft.AspNetCore.Mvc;
using SmartServe.Domain.Interfaces;
using SmartServe.Domain.Models;
using SmartServe.API.Models;
using SmartServe.Domain.Constants;
using SmartServe.API.Helper;

namespace SmartServe.API.Controllers
{
    [ApiController]
    [Route("api/order-reports")]
    public class OrderReportController : BaseController
    {
        private readonly IOrderReportService _service;

        public OrderReportController(IOrderReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(DateTime fromUtc, DateTime toUtc)
        {
            var response = new BaseResponseDto<OrderReportResult>();

            var result = await _service.GetOrdersAsync(fromUtc, toUtc);

            if (result == null || result.Orders == null || result.Orders.Count == 0)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = result;

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }

        [HttpGet]
        [Route("{orderId}/items")]
        public async Task<IActionResult> GetOrderItems(int orderId)
        {
            var response = new BaseResponseDto<List<OrderItem>>();

            var items = await _service.GetOrderItemsAsync(orderId);

            if (items == null || items.Count == 0)
            {
                HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.RecordNotFound);
                HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.RecordNotFound);

                return Ok(WithMappedError(response, ResultCodes.RecordNotFound, ResultMessages.RecordNotFound));
            }

            response.Data = items;

            HttpContext.CreateAnnotation(Annotations.ResultCode, ResultCodes.Success);
            HttpContext.CreateAnnotation(Annotations.ResultMessage, ResultMessages.Success);

            return Ok(response);
        }
    }
}
