
using System.Collections.Generic;
using Domain.Entities;

namespace auvo.Application.Interface
{

    public interface ITransacaoService
    {
        IEnumerable<Transacao> SalvarTransacoes(string historico);

        IEnumerable<Transacao> ObterTransacoes();

        Transacao ObterTransacao(int id);

        int DeletarArquivos();

        int InserirObservacao(int id, string observacao);
    }


}