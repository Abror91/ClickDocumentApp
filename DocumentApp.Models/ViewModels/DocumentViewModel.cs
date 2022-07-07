using DocumentApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.Models.ViewModels
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        public DocumentStatus Status { get; set; }
        public string Data { get; set; }
    }
}
