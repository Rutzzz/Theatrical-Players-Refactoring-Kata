using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
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

            foreach (var (perf, amount) in invoice.Performances)
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
            var result = new StringBuilder();

            using var writer = new IndentedTextWriter(new StringWriter(result), "  ");

            writer.WriteLine("<html>");
            writer.Indent++;

            writer.WriteLine($"<h1>Statement for {invoice.Customer}</h1>");
            writer.WriteLine("<table>");

            writer.Indent++;
            writer.WriteLine("<tr><th>play</th><th>seats</th><th>cost</th></tr>");
            
            foreach (var (perf, amount) in invoice.Performances)
            {
                Play play = perf.Play;
                writer.WriteLine(string.Format(CultureInfo, "<tr><td>{0}</td><td>{1}</td><td>{2:C}</td></tr>", play.Name, perf.Audience, Convert.ToDecimal(amount / 100)));
            }

            writer.Indent--;
            writer.WriteLine("</table>");
            writer.WriteLine(string.Format(CultureInfo, "<p>Amount owed is <em>{0:C}</em></p>", Convert.ToDecimal(invoice.TotalAmount / 100)));
            writer.WriteLine($"<p>You earned <em>{invoice.VolumeCredits}</em> credits</p>");
            
            writer.Indent--;
            writer.Write("</html>");

            return result.ToString();
        }
    }
}
