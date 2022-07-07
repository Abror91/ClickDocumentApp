using DocumentApp.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.DAL.Repositories.Abstractions
{
    public interface IDocumentRepository : IGenericRepository<DocumentItem>
    {
        Task<IEnumerable<DocumentItem>> FilterDocumentItems(int skip, int pageSize);
        Task UpdateDocumentPatch(JsonPatchDocument documentModel, Guid id);
    }
}
