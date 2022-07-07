using DocumentApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Models.ViewModels
{
    public class DocumentAddViewModel
    {

        [StringLength(5000)]
        public string Data { get; set; }

        public DocumentItem ToEntity()
        {
            return new DocumentItem() { Data = Data};
        }
    }
}
