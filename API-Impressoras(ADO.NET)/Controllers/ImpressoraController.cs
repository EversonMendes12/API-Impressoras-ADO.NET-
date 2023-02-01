using Api_Impressora_ADO.NET.Interfaces;
using Api_Impressora_ADO.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Impressora_ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpressoraController : ControllerBase
    {

        private IBmImpressora _REPOSITORY;
        public ImpressoraController()
        {
            _REPOSITORY = new BmImpressora();
        }

        [HttpGet]
        public IActionResult GetImpressoras()
        {

            return Ok(_REPOSITORY.GetImpressoras());

        }

        [HttpGet("{id}")]
        public IActionResult GetImpressora(int id)
        {

            var impressoraid = _REPOSITORY.GetImpressora(id);

            if (impressoraid == null)
            {
                return NotFound();//Se não for passado parametro ele retorna erro;
            }

            return Ok(impressoraid);
        }

        [HttpPost]
        public IActionResult AddImpressoras(ImpressoraModel model)
        {

            _REPOSITORY.AddImpressora(model);

            return Ok(model);


        }
    }
}
