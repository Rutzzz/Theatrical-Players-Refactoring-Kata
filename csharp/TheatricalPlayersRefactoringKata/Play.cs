using System;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        public string Name { get; set; }

        protected Play(string name) {
            Name = name;
        }

        public abstract int ComputePrice(int audience);

        public virtual int ComputeCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
