using EnocaChallenge.Business.Abstract;
using EnocaChallenge.Business.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;
        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<UrunVM> GetAllUrun()
        {
            return _urunService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateUrun(UrunVM urun)
        {
            return _urunService.Add(urun);

        }
        [HttpPut("Update")]
        public string UpdateUrun(UrunVM urun)
        {
            return _urunService.Update(urun);
        }
        [HttpGet("Delete/{id}")]
        public string DeleteUrun(int id)
        {
            return _urunService.Delete(id);
        }
    }
}
