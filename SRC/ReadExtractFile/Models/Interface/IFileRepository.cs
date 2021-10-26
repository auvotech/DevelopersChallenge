
using System;
using System.Collections.Generic;

namespace ReadExtractFile.Models.Interface
{
    public interface IFileRepository : IRepositoryBase<FinancialTransaction>
    {
        List<FinancialTransaction> ReadFile(List<string> path);
        List<FinancialTransaction> SearchByDate(DateTime FromDate, DateTime ToDate);
        List<FinancialTransaction> SearchByParameter(FinancialTransaction trans);
    }
}
