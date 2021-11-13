using System.Collections.Generic;
using auvo.Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api_auvo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Transacao>> CadastrarArquivoOFX([FromBody] Transacao ofx)
        {
            if (ofx.Historico == null)
            {
                return BadRequest("A transação está no formato incorreto");
            }

            return Ok(_transacaoService.SalvarTransacoes(ofx.Historico));
        }

    }
}
