using EnocaChallenge.Business.Abstract;
using EnocaChallenge.Business.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService _siparisService;
        public SiparisController(ISiparisService siparisService)
        {
            _siparisService = siparisService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<SiparisVM> GetAllSiparis()
        {
            return _siparisService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateSiparis(SiparisVM siparis)
        {
            return _siparisService.Add(siparis);

        }
        [HttpPut("Update")]
        public string UpdateSiparis(SiparisVM siparis)
        {
            return _siparisService.Update(siparis);
        }
        [HttpGet("Delete/{id}")]
        public string DeleteSiparis(int id)
        {
            return _siparisService.Delete(id);
        }
    }
}
