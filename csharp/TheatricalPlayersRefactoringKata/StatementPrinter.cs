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
            CultureInfo cultureInfo = new CultureInfo("en-US");
            var result = new StringBuilder("<html>").AppendLine();
            result.AppendLine($"  <h1>Stetement for {invoice.Customer}</h1>");
            result.AppendLine("  <table>");
            result.AppendLine("    <tr><th>play</th><th>seats</th><th>cost</th></tr>");
            foreach(var (perf, amount) in invoice.Performances) 
            {
                Play play = perf.Play;
                result.AppendFormat(cultureInfo, "    <tr><td>{0}</td><td>{1}</td><td>{2:C}</td></tr>", play.Name, perf.Audience,  Convert.ToDecimal(amount / 100)).AppendLine();
            }
            result.AppendLine("  </table>");
            result.AppendFormat(cultureInfo, "  <p>Amount owed is <em>{0:C}</em></p>", Convert.ToDecimal(invoice.TotalAmount / 100)).AppendLine();
            result.AppendLine($"  <p>You earned <em>{invoice.VolumeCredits}</em> credits</p>");
            result.Append("</html>");
            return result.ToString();
        }
    }
}
