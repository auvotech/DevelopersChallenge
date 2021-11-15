using System.Collections.Generic;
using System.Linq;
using DevelopersChallenge.src.auvo.Domain.Interfaces.IRepositorys;
using Domain.Entities;
using Infrastructure;

namespace DevelopersChallenge.src.auvo.Persistence.Repository
{

    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AuvoContext _auvoContext;

        public TransacaoRepository(AuvoContext geniusContext)
        {
            _auvoContext = geniusContext;
        }

        public IEnumerable<Transacao> SalvarTransacoes(IEnumerable<Transacao> transacoes)
        {
            foreach (var transacao in transacoes)
            {
                _auvoContext.Transacao.Add(transacao);
                _auvoContext.SaveChanges();
            }

            return ObterTransacoes();

        }

        public IEnumerable<Transacao> ObterTransacoes()
        {
            return _auvoContext.Transacao.ToList();

        }

        public Transacao ObterTransacao(int id)
        {

            var transacao = _auvoContext.Transacao.FirstOrDefault(x => x.Id == id);

            return transacao;
        }

        public int InserirObservacao(int id, string observacao)
        {
            var transacao = _auvoContext.Transacao.FirstOrDefault(x => x.Id == id);

            transacao.Observacao = observacao;

            return _auvoContext.SaveChanges();

        }

        public int DeletarArquivos()
        {
            foreach (var entity in _auvoContext.Transacao)
            {
                _auvoContext.Transacao.Remove(entity);

            }

            return _auvoContext.SaveChanges();

        }
    }
}
