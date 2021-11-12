using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace api_auvo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<Transacao> CadastrarArquivoOFX([FromBody] Transacao ofx)
        {
            Regex regex = new Regex("(?<=<STMTTRN>).*?(?=</STMTTRN>)", RegexOptions.RightToLeft);

            MatchCollection historicos = regex.Matches(ofx.Historico);

            List<Transacao> transacoes = new List<Transacao>();

            for (int ctr = 0; ctr < historicos.Count; ctr++)
            {
                Transacao transacao = new Transacao();
                transacao.Valor = ObterItemTransacao("(?<=<TRNAMT>).*?(?=<MEMO>)", historicos[ctr].Value);
                transacao.Descricao = ObterItemTransacao("(?<=<MEMO>).*?(?=)", historicos[ctr].Value);
                transacao.Operacao = ObterItemTransacao("(?<=<TRNTYPE>).*?(?=<DTPOSTED>)", historicos[ctr].Value);
                transacao.DataLancamento = ObterItemTransacao("(?<=<DTPOSTED>).*?(?=<TRNAMT>)", historicos[ctr].Value);
                transacoes.Add(transacao);
            }

            return transacoes;
        }

        private static string ObterItemTransacao(string filtro, string historico)
        {
            Regex regex = new Regex(filtro, RegexOptions.RightToLeft);

            return regex.Matches(historico).FirstOrDefault().Value;
        }

    }
}
