namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public abstract int ComputePrice(int audience);

        public Play(string name) {
            this._name = name;
        }
    }
}
