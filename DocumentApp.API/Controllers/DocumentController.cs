using DocumentApp.BLL.Services.Abstractions;
using DocumentApp.Models.Enums;
using DocumentApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DocumentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentViewModel>> FilterDocumentItems([FromQuery] PaginationQueryParams queryParams)
        {
            return  await _documentService.FilterDocuments(queryParams.Page, queryParams.PerPage);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _documentService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDocumentItem([FromBody] DocumentAddViewModel model)
        {
            await _documentService.Add(model);

            return Ok();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] JsonPatchDocument patchItem)
        {
            var item = await _documentService.GetById(id);

            if (item == null)
                return NotFound();

            if (item.Status == DocumentStatus.Published)
                return BadRequest();

            await _documentService.UpdateDocumentPatch(patchItem, id);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/Publish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Publish([FromRoute] Guid id)
        {
            var item = await _documentService.GetById(id);

            if (item == null)
                return NotFound();

            if (item.Status == DocumentStatus.Published)
                return Ok();

            await _documentService.PublishDocument(id);

            return Ok();
        }
    }
}
