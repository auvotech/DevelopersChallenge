using Microsoft.EntityFrameworkCore;

namespace ReadExtractFile.Models
{
    public class ReadExtractFileContext : DbContext
    {
        public ReadExtractFileContext(DbContextOptions<ReadExtractFileContext> options)
        : base(options) { }

        public DbSet<FinancialTransaction> FinancialTransaction { get; set; }
    }
}
