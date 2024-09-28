using System.ComponentModel.DataAnnotations;

namespace CertificateService.Models
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Cost { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
