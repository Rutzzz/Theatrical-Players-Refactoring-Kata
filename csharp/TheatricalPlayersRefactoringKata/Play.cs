using System;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public Play(string name) {
            this._name = name;
        }
        public abstract int ComputePrice(int audience);

        public virtual int ComputeCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
