
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadExtractFile.Models
{
    public class FinancialTransaction
    {
        [Key]
        public int ID_TRANSACTION { get; set; }
        public decimal TRNAMT { get; set; }
        public string TRNTYPE { get; set; }
        public DateTime DTPOSTED { get; set; }
        public string MEMO { get; set; }
        public string OBS{ get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
