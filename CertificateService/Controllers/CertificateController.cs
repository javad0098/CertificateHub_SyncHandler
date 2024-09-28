using System.Collections.Generic; // Ensure to include the correct namespaces for IEnumerable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CertificateService.Data;
using CertificateService.Models;
using CertificateService.Dtos;

namespace CertificateService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : ControllerBase
    {

        private readonly IMapper _maper;
        private readonly ICertificateRepo _repository;
        public CertificateController(ICertificateRepo repository, IMapper maper)
        {
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
        public ActionResult<Certificate> CreateCertificate(CertificateCreateDtos certificateCreate)
        {
            var certificate = _maper.Map<Certificate>(certificateCreate);
            _repository.CreateCertificate(certificate);
            _repository.SaveChenges();
            var certificateReadDto = _maper.Map<CertificateReadDto>(certificate);
            return CreatedAtRoute(nameof(GetCertificateById), new { id = certificateReadDto.Id }, certificateReadDto);
        }
    }
}
