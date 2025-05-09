namespace Lab_8
{
    public abstract class Purple
    {
        public string Input { get; private set; }

        public Purple(string input)
        {
            this.Input = input;
        }

        public abstract void Review();
    }
}
