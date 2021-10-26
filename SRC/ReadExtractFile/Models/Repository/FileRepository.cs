using ReadExtractFile.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ReadExtractFile.Models
{
    public class FileRepository : RepositoryBase<FinancialTransaction>, IFileRepository
    {
        protected ReadExtractFileContext Db = new ReadExtractFileContext(DbContextHelper.GetDbContextOptions());
        public List<FinancialTransaction> ReadFile(List<string> pathFiles)
        {
            List<FinancialTransaction> ListFinancialTransactions = new List<FinancialTransaction>();

            foreach (var fileToRead in pathFiles)
            {

                if (!File.Exists(fileToRead))
                {
                    throw new FileNotFoundException();
                }

                var tags = from line in File.ReadAllLines(fileToRead)
                           where line.Contains("<STMTTRN>") ||
                           line.Contains("<TRNTYPE>") ||
                           line.Contains("<DTPOSTED>") ||
                           line.Contains("<TRNAMT>") ||
                           line.Contains("<MEMO>")
                           select line;

                XElement el = new XElement("OFX");
                FinancialTransaction trans = null;

                foreach (var l in tags)
                {
                    if (l.IndexOf("<STMTTRN>") != -1)
                        trans = new FinancialTransaction();

                    if (l.IndexOf("<TRNTYPE>") != -1)
                        trans.TRNTYPE = getTagValue(l);

                    if (l.IndexOf("<DTPOSTED>") != -1)
                        trans.DTPOSTED = DateTime.Parse(getTagValue(l).Insert(4, "-").Insert(7, "-"));

                    if (l.IndexOf("<TRNAMT>") != -1)
                        trans.TRNAMT = decimal.Parse(getTagValue(l).Replace("-", ""));

                    if (l.IndexOf("<MEMO>") != -1)
                        trans.MEMO = getTagValue(l);

                    if (l.IndexOf("<STMTTRN>") != -1)
                        ListFinancialTransactions.Add(trans);
                }
            }

            return ListFinancialTransactions;
        }
        public List<FinancialTransaction> SearchByDate(DateTime FromDate, DateTime ToDate)
        {
            return Db.Set<FinancialTransaction>().Where(x => x.DTPOSTED >= FromDate && x.DTPOSTED <= ToDate).ToList();
        }

        public List<FinancialTransaction> SearchByParameter(FinancialTransaction trans)
        {

            return Db.Set<FinancialTransaction>().Where(x =>
              x.TRNTYPE == trans.TRNTYPE &&
              x.TRNAMT == trans.TRNAMT &&
              x.DTPOSTED == trans.DTPOSTED &&
              x.MEMO == trans.MEMO).ToList();


        }

        private static string getTagValue(string line)
        {
            int pos_init = line.IndexOf(">") + 1;
            string retValue = line.Substring(pos_init).Trim();
            if (retValue.IndexOf("[") != -1)
            {
                retValue = retValue.Substring(0, 8);
            }
            return retValue;
        }
    }
}
