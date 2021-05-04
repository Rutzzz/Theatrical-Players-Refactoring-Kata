using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public CultureInfo CultureInfo { get; set; } = new("en-US");

        public string Print(Invoice invoice)
        {
            var result = new StringBuilder($"Statement for {invoice.Customer}\n");

            foreach(var (perf, amount) in invoice.Performances) 
            {
                Play play = perf.Play;
                result.AppendFormat(CultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(amount / 100), perf.Audience);
            }

            result.AppendFormat(CultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(invoice.TotalAmount / 100));
            result.Append($"You earned {invoice.VolumeCredits} credits\n");
            
            return result.ToString();
        }
        
        public string PrintAsHtml(Invoice invoice)
        {
            var result = new StringBuilder("<html>").AppendLine();
            result.AppendLine($"  <h1>Statement for {invoice.Customer}</h1>");
            result.AppendLine("  <table>");
            result.AppendLine("    <tr><th>play</th><th>seats</th><th>cost</th></tr>");

            foreach(var (perf, amount) in invoice.Performances) 
            {
                Play play = perf.Play;
                result.AppendFormat(CultureInfo, "    <tr><td>{0}</td><td>{1}</td><td>{2:C}</td></tr>", play.Name, perf.Audience,  Convert.ToDecimal(amount / 100)).AppendLine();
            }

            result.AppendLine("  </table>");
            result.AppendFormat(CultureInfo, "  <p>Amount owed is <em>{0:C}</em></p>", Convert.ToDecimal(invoice.TotalAmount / 100)).AppendLine();
            result.AppendLine($"  <p>You earned <em>{invoice.VolumeCredits}</em> credits</p>");
            result.Append("</html>");

            return result.ToString();
        }
    }
}
