using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkeyWebRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Category Order")]
        [Range(1, 100, ErrorMessage = "Display Order range should be 1-100")]
        public int DisplayOrder { get; set; }
    }
}
