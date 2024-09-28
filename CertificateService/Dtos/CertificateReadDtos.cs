
namespace CertificateService.Dtos
{
    public class CertificateReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
