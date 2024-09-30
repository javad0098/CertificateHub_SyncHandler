using System.Collections.Generic; // Ensure to include the correct namespaces for IEnumerable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CertificateService.Data;
using CertificateService.Models;
using CertificateService.Dtos;
using CertificateService.SyncDataServices.Http;

namespace CertificatesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ISkillDataClient _skillDataClient;
        private readonly IMapper _maper;
        private readonly ICertificateRepo _repository;
        public CertificatesController(ICertificateRepo repository, IMapper maper, ISkillDataClient skillDataClient)
        {
            _skillDataClient = skillDataClient;
            _maper = maper;
            _repository = repository;
        }
        // GET api/platforms
        [HttpGet]
        public ActionResult<IEnumerable<Certificate>> GetCertificates()
        {

            Console.WriteLine(">> Getting All Platforms");

            // Retrieve platforms from the repository
            var certificates = _repository.GetAllCertificates();

            // Map platforms to PlatformReadDto and return the result
            return Ok(_maper.Map<IEnumerable<CertificateReadDto>>(certificates));
        }

        [HttpGet("{id}", Name = "GetCertificateById")]
        public ActionResult<Certificate> GetCertificateById(int id)
        {


            // Retrieve platforms from the repository
            var certificate = _repository.GetCertificateById(id);

            if (certificate != null)
            {
                return Ok(_maper.Map<CertificateReadDto>(certificate));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> CreateCertificate(CertificateCreateDtos certificateCreate)
        {
            var certificate = _maper.Map<Certificate>(certificateCreate);
            _repository.CreateCertificate(certificate);
            _repository.SaveChenges();
            var certificateReadDto = _maper.Map<CertificateReadDto>(certificate);
            try
            {
                await _skillDataClient.SendCertificateToSkill(certificateReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"==> could not send synchronously: {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetCertificateById), new { id = certificateReadDto.Id }, certificateReadDto);
        }
    }
}
