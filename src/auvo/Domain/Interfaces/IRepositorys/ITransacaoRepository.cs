using System.Transactions;
using System;
using System.Collections.Generic;
using Domain.Entities;

namespace DevelopersChallenge.src.auvo.Domain.Interfaces.IRepositorys
{

    public interface ITransacaoRepository
    {
        IEnumerable<Transacao> SalvarTransacoes(IEnumerable<Transacao> transacoes);
    }


}