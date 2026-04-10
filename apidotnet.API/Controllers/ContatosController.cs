using apidotnet.DTOs;
using apidotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoService _service;

        public ContatosController(IContatoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ContatoCreateDto dto)
        {
            var result = await _service.Criar(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _service.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            return Ok(await _service.Obter(id));
        }

        [HttpPatch("{id}/desativar")]
        public async Task<IActionResult> Desativar(int id)
        {
            await _service.Desativar(id);
            return NoContent();
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> Ativar(int id)
        {
            await _service.Ativar(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _service.Excluir(id);
            return NoContent();
        }
    }
}