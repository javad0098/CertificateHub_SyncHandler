using CertificateService.Models;


namespace CertificateService.Data
{
    public interface ICertificateRepo
    {
        bool SaveChenges();
        IEnumerable<Certificate> GetAllCertificates();
        Certificate GetCertificateById(int Id);
        void CreateCertificate(Certificate certificate);
    }
}