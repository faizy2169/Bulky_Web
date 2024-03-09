using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkeyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Category Order")]
        [Range(1,100, ErrorMessage = "Display Order range should be 1-100")]
        public int DisplayOrder { get; set; }
    }
}
