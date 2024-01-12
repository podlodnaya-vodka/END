using END.Application.DTO;
using END.Application.Interfaces.Services;
using END.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace END.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AttributeValueController : ControllerBase
    {
        IAttributeValueService _service;
        readonly ILogger _logger;
        public AttributeValueController(IAttributeValueService service, ILogger<AttributeValueController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById(Guid id)
        {
            try
            {
                var res = await _service.GetByIdAsync(id);
                if (!(res is null))
                    _logger.LogDebug($"AttributeValueController GetById {id} is null");
                else
                    _logger.LogDebug($"AttributeValueController GetById {id} is Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"AttributeValueController GetById {id} Exception:{ex}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete(Guid id)
        {

            try
            {
                var res = await _service.DeleteAsync(id);
                if (res)
                    _logger.LogDebug($"AttributeValueController Delete {id} null");
                else
                    _logger.LogDebug($"AttributeValueController Delete {id} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"AttributeValueController Delete {id} Exception:{ex}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromQuery] AttributeValueDto dto)
        {
            try
            {
                var res = await _service.CreateAsync(dto);
                if (res)
                    _logger.LogDebug($"AttributeValueController Create {dto.Name} {dto.Value} for Document {dto.DocumentId} Error");
                else
                    _logger.LogDebug($"AttributeValueController Create {dto.Name} {dto.Value} for Document {dto.DocumentId} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"AttributeValueController CreateDocument {dto.Name} {dto.Value} for Document {dto.DocumentId} Exception:{ex}");
                return BadRequest();
            }
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update(Guid id, [FromQuery] AttributeValueDto dto)
        {
            try
            {
                var res = await _service.UpdateAsync(id, dto);
                if (res)
                    _logger.LogDebug($"AttributeValueController Update {id} {dto.Name} {dto.Value} for Document {dto.DocumentId} Error");
                else
                    _logger.LogDebug($"AttributeValueController Update {id} {dto.Name} {dto.Value} for Document {dto.DocumentId} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"AttributeValueController UpdateProduct  {id} {dto.Name} {dto.Value} for Document {dto.DocumentId} Exception:{ex}");
                return BadRequest();
            }
        }
    }
}
