using DocumentApp.Models.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace DocumentApp.BLL.Services.Abstractions
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentViewModel>> FilterDocuments(int pageNumber, int pageSize);
        Task<DocumentViewModel> GetById(Guid id);
        Task Add(DocumentAddViewModel model);
        Task UpdateDocumentPatch(JsonPatchDocument documentModel, Guid id);
        Task PublishDocument(Guid Id);
    }
}
