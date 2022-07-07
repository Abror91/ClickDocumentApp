using DocumentApp.Models.Entities;
using DocumentApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
