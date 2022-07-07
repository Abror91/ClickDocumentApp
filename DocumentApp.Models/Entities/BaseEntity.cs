using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
