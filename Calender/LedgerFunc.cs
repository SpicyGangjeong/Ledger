using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger
{
    public class LedgerFunc
    {
        public string replaceQuotetoSlashQuote(string text)
        {
            // 인용부호를 이스케이프 처리
            text = text.Replace("\"", "\\\"");
            text = text.Replace("\'", "\\\'");
            return text;
        }
    }
}
