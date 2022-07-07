using DocumentApp.DAL.Repositories.Abstractions;
using DocumentApp.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.DAL.Repositories.Implementations
{
    public class DocumentRepository : GenericRepository<DocumentItem>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<DocumentItem>> FilterDocumentItems(int skip, int pageSize)
        {
            return await _entities.OrderByDescending(s => EF.Property<DateTime>(s, "CreatedDate")).Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task UpdateDocumentPatch(JsonPatchDocument documentModel, Guid id)
        {
            var entity = await _entities.FirstOrDefaultAsync(s => s.Id == id);

            if (entity != null)
                documentModel.ApplyTo(entity);
        }
    }
}
