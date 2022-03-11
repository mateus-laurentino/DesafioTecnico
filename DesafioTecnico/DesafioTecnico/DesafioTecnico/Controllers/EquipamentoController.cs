using Microsoft.AspNetCore.Mvc;
using DesafioTecnico.Servicos;
using DesafioTecnico.Model;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        private IEquipamentoServico _equipamentoServico;

        public EquipamentoController(IEquipamentoServico equipamentoServico)
        {
            _equipamentoServico = equipamentoServico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_equipamentoServico.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var equipamento = _equipamentoServico.FindById(id);
            if(equipamento == null) return NotFound();
            return Ok(equipamento);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Equipamento equipamento)
        {
            if(equipamento == null) return BadRequest();
            return Ok(_equipamentoServico.Create(equipamento));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Equipamento equipamento)
        {
            if (equipamento == null) return BadRequest();
            return Ok(_equipamentoServico.Update(equipamento));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _equipamentoServico.Delete(id);
            return NoContent();
        }
    }
}
