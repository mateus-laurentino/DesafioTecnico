using Microsoft.AspNetCore.Mvc;
using DesafioTecnico.Servicos;
using DesafioTecnico.Model;
using System.Collections.Generic;

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
        [ProducesResponseType((200),Type = typeof(List<Equipamento>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get()
        {
            return Ok(_equipamentoServico.FindAll());
        }

        [HttpGet("patrimonio/{patrimonio}")]
        [ProducesResponseType((200), Type = typeof(Equipamento))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get(int patrimonio)
        {
            var equipamento = _equipamentoServico.FindByPatrimonio(patrimonio);
            if(equipamento == null) return NotFound();
            return Ok(equipamento);
        }

        [HttpGet("descricao/{Descricao}")]
        [ProducesResponseType((200), Type = typeof(List<Equipamento>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get(string Descricao)
        {
            var equipamento = _equipamentoServico.FindByDescricao(Descricao);
            if (equipamento == null) return NotFound("Nada encontrado");
            return Ok(equipamento);
        }


        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Equipamento))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] Equipamento equipamento)
        {
            /*if(equipamento == null) return BadRequest();
            return Ok(_equipamentoServico.Create(equipamento));*/
            var resultado = _equipamentoServico.Create(equipamento);
            if(resultado == null) return BadRequest("Faltam informações para adicionar o produto");
            else return Ok(resultado);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Equipamento))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Put([FromBody] Equipamento equipamento)
        {
            if (equipamento == null) return BadRequest();
            return Ok(_equipamentoServico.Update(equipamento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(int id)
        {
            _equipamentoServico.Delete(id);
            return NoContent();
        }
    }
}
