using DocumentApp.BLL.Services.Abstractions;
using DocumentApp.DAL.Repositories.Abstractions;
using DocumentApp.Models.Enums;
using DocumentApp.Models.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace DocumentApp.BLL.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<DocumentViewModel>> FilterDocuments(int pageNumber, int pageSize)
        {
            var entities = await _documentRepository.FilterDocumentItems((pageNumber - 1) * pageSize, pageSize);

            var models = new List<DocumentViewModel>();

            foreach (var entity in entities)
                models.Add(entity.ToViewModel());

            return models;
        }

        public async Task<DocumentViewModel> GetById(Guid id)
        {
            var entity = await _documentRepository.GetByIdAsync(id);

            if (entity != null)
                return entity.ToViewModel();
            else
                return null;
        }

        public async Task Add(DocumentAddViewModel model)
        {
            var entity = model.ToEntity();
            entity.Status = DocumentStatus.Draft;

            _documentRepository.Add(entity);

            await _documentRepository.SaveChangesAsync();
        }

        public async Task UpdateDocumentPatch(JsonPatchDocument documentModel, Guid id)
        {
            await _documentRepository.UpdateDocumentPatch(documentModel, id);

            await _documentRepository.SaveChangesAsync();
        }

        public async Task PublishDocument(Guid Id)
        {
            var entity = await _documentRepository.GetByIdAsync(Id);

            entity.Status = DocumentStatus.Published;

            await _documentRepository.SaveChangesAsync();
        }
    }
}
