using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata
{
    public class Invoice
    {
        public string Customer { get; set; }

        public Dictionary<Performance, int> Performances { get; set; } = new();
        public int VolumeCredits { get; set; }
        public int TotalAmount { get; set; }

        public Invoice(string customer, List<Performance> performance)
        {
            Customer = customer;
            var totalAmount = 0;
            var volumeCredits = 0;

            foreach (var perf in performance)
            {
                var play = perf.Play;
                var thisAmount = play.ComputePrice(perf.Audience);

                Performances[perf] = thisAmount;
                volumeCredits += play.ComputeCredits(perf.Audience);
                totalAmount += thisAmount;
            }
            VolumeCredits = volumeCredits;
            TotalAmount = totalAmount;
        }

    }
}
