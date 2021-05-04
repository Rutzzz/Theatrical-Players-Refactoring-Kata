using System;
using System.Globalization;
using System.Text;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = new StringBuilder($"Statement for {invoice.Customer}\n");
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var perf in invoice.Performances) 
            {
                var play = perf.Play;
                var thisAmount = play.ComputePrice(perf.Audience);

                volumeCredits += play.ComputeCredits(perf.Audience);

                // print line for this order
                result.AppendFormat(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
                totalAmount += thisAmount;
            }

            result.AppendFormat(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
            result.Append($"You earned {volumeCredits} credits\n");
            
            return result.ToString();
        }

        public string PrintAsHtml(Invoice invoice)
        {
            return string.Empty;
        }
    }
}
