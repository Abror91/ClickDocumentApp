using DocumentApp.Models.Enums;

namespace DocumentApp.Models.ViewModels
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        public DocumentStatus Status { get; set; }
        public string Data { get; set; }
    }
}
