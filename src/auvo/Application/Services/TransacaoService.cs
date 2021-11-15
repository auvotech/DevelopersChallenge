using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using auvo.Application.Interface;
using DevelopersChallenge.src.auvo.Domain.Interfaces.IRepositorys;
using Domain.Entities;

namespace auvo.Application.Services
{

    public class TransacaoService : ITransacaoService
    {

        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        private static string ObterItemTransacao(string filtro, string historico)
        {
            Regex regex = new Regex(filtro, RegexOptions.RightToLeft);

            return regex.Matches(historico).FirstOrDefault().Value;
        }

        private IEnumerable<Transacao> ConverterTransacoesParaJson(string historico)
        {
            Regex regex = new Regex("(?<=<STMTTRN>).*?(?=</STMTTRN>)", RegexOptions.RightToLeft);

            MatchCollection historicos = regex.Matches(historico);

            List<Transacao> transacoes = new List<Transacao>();

            for (int ctr = 0; ctr < historicos.Count; ctr++)
            {
                Transacao transacao = new Transacao();
                transacao.Valor = float.Parse(ObterItemTransacao("(?<=<TRNAMT>).*?(?=<MEMO>)", historicos[ctr].Value));
                transacao.Descricao = ObterItemTransacao("(?<=<MEMO>).*?(?=)", historicos[ctr].Value);
                transacao.Operacao = ObterItemTransacao("(?<=<TRNTYPE>).*?(?=<DTPOSTED>)", historicos[ctr].Value);
                string data = ObterItemTransacao("(?<=<DTPOSTED>).*?(?=<TRNAMT>)", historicos[ctr].Value).Substring(0, 8);
                transacao.DataLancamento = DateTime.ParseExact(data, "yyyyMMdd", null);
                transacoes.Add(transacao);
            }

            return transacoes;
        }

        public IEnumerable<Transacao> SalvarTransacoes(string historico)
        {
            IEnumerable<Transacao> transacoes = ConverterTransacoesParaJson(historico);

            return _transacaoRepository.SalvarTransacoes(transacoes);
        }

        public IEnumerable<Transacao> ObterTransacoes()
        {
            return _transacaoRepository.ObterTransacoes();
        }

        public Transacao ObterTransacao(int id)
        {
            return _transacaoRepository.ObterTransacao(id);
        }

        public int InserirObservacao(int id,string observacao)
        {
            return _transacaoRepository.InserirObservacao(id,observacao);
        }
    }
}