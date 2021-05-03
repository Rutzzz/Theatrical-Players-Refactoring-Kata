using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class ComedyPlay : Play
    {
        public ComedyPlay(string name) : base(name)
        {
        }

        public override int ComputeCredits(int audience)
        {
            var credits = base.ComputeCredits(audience);
            credits += (int)Math.Floor((decimal)audience / 5);
            return credits;
        }

        public override int ComputePrice(int audience)
        {
            int thisAmount = 30000;
            if (audience > 20)
            {
                thisAmount += 10000 + 500 * (audience - 20);
            }
            thisAmount += 300 * audience;
            return thisAmount;
        }
    }
}
