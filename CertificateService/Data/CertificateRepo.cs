using CertificateService.Models;


namespace CertificateService.Data
{
    public class CertificateRepo : ICertificateRepo
    {

        private readonly AppDBContext _context;
        public CertificateRepo(AppDBContext context)
        {
            _context = context;

        }
        public void CreateCertificate(Certificate certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException(nameof(certificate));

            }
            _context.Certificates.Add(certificate);

        }

        public IEnumerable<Certificate> GetAllCertificates()
        {
            return _context.Certificates.ToList();
        }

        public Certificate GetCertificateById(int id)
        {
            return _context.Certificates.FirstOrDefault(certificate => certificate.Id == id) ?? new Certificate(); // Use a default or fallback
        }

        public bool SaveChenges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
