using END.Application.DTO;
using END.Application.Interfaces.Services;
using END.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace END.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        IDocumentService _service;
        readonly ILogger _logger;
        public DocumentController(IDocumentService service, ILogger<DocumentController> logger)
        {
            _service = service;
            _logger = logger;
            
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetAll()
        {
            try
            {
                _logger.LogDebug("DocumentController GetAll");
                var res = await _service.GetAllAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentController GetAll Exception:{ex}");
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById(Guid id)
        {
            try
            {
                var res = await _service.GetByIdAsync(id);
                if(!(res is null))
                    _logger.LogDebug($"DocumentController GetById {id} is null");
                else
                    _logger.LogDebug($"DocumentController GetById {id} is Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentController GetById {id} Exception:{ex}");
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
                    _logger.LogDebug($"DocumentController Delete {id} null");
                else
                    _logger.LogDebug($"DocumentController Delete {id} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentController Delete {id} Exception:{ex}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromQuery] DocumentDto dto)
        {
            try
            {
                var res = await _service.CreateAsync(dto);
                if (res)
                    _logger.LogDebug($"DocumentController Create {dto.Name} {dto.Type} Error");
                else
                    _logger.LogDebug($"DocumentController Create {dto.Name} {dto.Type} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentController CreateDocument {dto.Name} {dto.Type} Exception:{ex}");
                return BadRequest();
            }
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update(Guid id, [FromQuery] DocumentDto dto)
        {
            try
            {
                var res = await _service.UpdateAsync(id, dto);
                if (res)
                    _logger.LogDebug($"DocumentController Update {id} {dto.Name} {dto.Type} Error");
                else
                    _logger.LogDebug($"DocumentController Update {id} {dto.Name} {dto.Type} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentController UpdateProduct  {id} {dto.Name} {dto.Type} Exception:{ex}");
                return BadRequest();
            }
        }
    }
}
