using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTecnico.Servicos;
using DesafioTecnico.Model;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        //private readonly ILogger<EquipamentoController> _logger;
        private IEquipamentoServico _equipamentoServico;

        public EquipamentoController(/*ILogger<EquipamentoController> logger*/IEquipamentoServico equipamentoServico)
        {
            //_logger = logger;
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
