namespace TheatricalPlayersRefactoringKata
{
    public class TragedyPlay : Play
    {
        public TragedyPlay(string name) : base(name)
        {
        }

        public override int ComputePrice(int audience)
        {
            var thisAmount = 40000;
            if (audience > 30) {
                thisAmount += 1000 * (audience - 30);
            }
            return thisAmount;
        }
    }
}