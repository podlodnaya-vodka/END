using END.Application.DTO;
using END.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace END.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DocumentLinkController : ControllerBase
    {
        IDocumentLinkService _service;
        readonly ILogger _logger;
        public DocumentLinkController(IDocumentLinkService service, ILogger<DocumentLinkController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetAll()
        {
            try
            {
                _logger.LogDebug("DocumentLinkController GetAll");
                var res = await _service.GetAllAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentLinkController GetAll Exception:{ex}");
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById(Guid id)
        {
            try
            {
                var res = await _service.GetByIdAsync(id);
                if (!(res is null))
                    _logger.LogDebug($"DocumentLinkController GetById {id} is null");
                else
                    _logger.LogDebug($"DocumentLinkController GetById {id} is Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentLinkController GetById {id} Exception:{ex}");
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
                    _logger.LogDebug($"DocumentLinkController Delete {id} null");
                else
                    _logger.LogDebug($"DocumentLinkController Delete {id} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentLinkController Delete {id} Exception:{ex}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromQuery] DocumentLinkDto dto)
        {
            try
            {
                var res = await _service.CreateAsync(dto);
                if (res)
                    _logger.LogDebug($"DocumentLinkController Create > {dto.ParentDocumentId} > {dto.ChildDocumentId} Error");
                else
                    _logger.LogDebug($"DocumentLinkController Create > {dto.ParentDocumentId} > {dto.ChildDocumentId} Ok");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DocumentLinkController CreateDocument > {dto.ParentDocumentId} > {dto.ChildDocumentId} Exception:{ex}");
                return BadRequest();
            }
        }
    }
}
