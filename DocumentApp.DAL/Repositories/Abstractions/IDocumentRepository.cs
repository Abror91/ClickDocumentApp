using DocumentApp.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace DocumentApp.DAL.Repositories.Abstractions
{
    public interface IDocumentRepository : IGenericRepository<DocumentItem>
    {
        Task<IEnumerable<DocumentItem>> FilterDocumentItems(int skip, int pageSize);
        Task UpdateDocumentPatch(JsonPatchDocument documentModel, Guid id);
    }
}
