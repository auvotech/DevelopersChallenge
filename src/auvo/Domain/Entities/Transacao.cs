using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transacao
    {
        [NotMapped]
        public string Historico { get; set; }

        public int Id { get; set; }

        public string Operacao { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Valor { get; set; }

        public string Descricao { get; set; }
    }
}