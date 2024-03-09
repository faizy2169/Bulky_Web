using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkeyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public required string Name { get; set; }
        [DisplayName("Category Order")]
        public int DisplayOrder { get; set; }
    }
}
