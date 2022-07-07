using DocumentApp.Models.Enums;
using DocumentApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Models.Entities
{
    public class DocumentItem : BaseEntity
    {
        public DocumentStatus Status { get; set; }

        [Required]
        [StringLength(5000)]
        public string Data { get; set; }

        public DocumentViewModel ToViewModel()
        {
            return new DocumentViewModel() { Id = Id, Status = Status, Data = Data };
        }
    }
}
