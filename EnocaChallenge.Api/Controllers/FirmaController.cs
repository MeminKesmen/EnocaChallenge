using EnocaChallenge.Business.Abstract;
using EnocaChallenge.Business.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaService _firmaService;
        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<FirmaVM> GetAllFirma()
        {
            return _firmaService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateFirma(FirmaVM firma)
        {
            return _firmaService.Add(firma);

        }
        [HttpPut("Update")]
        public string UpdateFirma(FirmaVM firma)
        {
            return _firmaService.Update(firma);
        }
        [HttpGet("Delete/{id}")]
        public string DeleteFirma(int id)
        {
            return _firmaService.Delete(id);
        }
    }
}
