using System;
using System.Globalization;
using System.Text;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice)
        {
            var result = new StringBuilder($"Statement for {invoice.Customer}\n");
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var (perf, amount) in invoice.Performances) 
            {
                Play play = perf.Play;
                result.AppendFormat(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(amount / 100), perf.Audience);
            }

            result.AppendFormat(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(invoice.TotalAmount / 100));
            result.Append($"You earned {invoice.VolumeCredits} credits\n");
            
            return result.ToString();
        }

        public string PrintAsHtml(Invoice invoice)
        {
            return string.Empty;
        }
    }
}
