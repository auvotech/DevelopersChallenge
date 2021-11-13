using System;
using System.Collections.Generic;
using System.Linq;
using DevelopersChallenge.src.auvo.Domain.Interfaces.IRepositorys;
using Domain.Entities;

namespace DevelopersChallenge.src.auvo.Persistence.Repository
{

    public class TransacaoRepository : ITransacaoRepository
    {
        
        public TransacaoRepository()
        {
            
        }

        public IEnumerable<Transacao> SalvarTransacoes(IEnumerable<Transacao> transacoes)
        {
            throw new NotImplementedException();
        }
    }


}