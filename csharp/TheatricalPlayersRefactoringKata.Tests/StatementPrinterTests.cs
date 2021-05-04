using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TheatricalPlayersRefactoringKata.Tests
{
    [TestFixture]
    public class StatementPrinterTests
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void test_statement_plain_text_example()
        {
            Invoice invoice = new Invoice("BigCo", new List<Performance>{
                new Performance( new TragedyPlay("Hamlet"), 55),
                new Performance( new ComedyPlay("As You Like It"), 35),
                new Performance( new TragedyPlay("Othello"), 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice);
            
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void test_statement_html_example()
        {
            Invoice invoice = new Invoice("BigCo", new List<Performance>{
                new Performance( new TragedyPlay("Hamlet"), 55),
                new Performance( new ComedyPlay("As You Like It"), 35),
                new Performance( new TragedyPlay("Othello"), 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            
            // Not implemented yet
            // var result = statementPrinter.PrintAsHtml(invoice);
            // Approvals.Verify(result);
        }

        // [Test]
        // [UseReporter(typeof(DiffReporter))]
        // public void test_statement_with_new_play_types()
        // {
        //     var plays = new Dictionary<string, Play>();
        //     plays.Add("henry-v", new Play("Henry V", "history"));
        //     plays.Add("as-like", new Play("As You Like It", "pastoral"));
        //
        //     Invoice invoice = new Invoice("BigCoII", new List<Performance>{new Performance("henry-v", 53),
        //         new Performance("as-like", 55)});
        //     
        //     StatementPrinter statementPrinter = new StatementPrinter();
        //
        //     Assert.Throws<Exception>(() => statementPrinter.Print(invoice, plays));
        // }
    }
}
