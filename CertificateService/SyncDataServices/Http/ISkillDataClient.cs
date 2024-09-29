using CertificateService.Dtos;

namespace CertificateService.SyncDataServices.Http
{
    public interface ISkillDataClient
    {
        Task SendCertificateToSkill(CertificateReadDto cer);
    }
}
