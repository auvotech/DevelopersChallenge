
using System.Collections.Generic;
using Domain.Entities;

namespace auvo.Application.Interface
{

    public interface ITransacaoService
    {
        IEnumerable<Transacao> SalvarTransacoes(string historico);
    }


}