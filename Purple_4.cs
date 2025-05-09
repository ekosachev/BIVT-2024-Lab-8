namespace Lab_8
{
    public class Purple_4 : Purple
    {
        public string Output { get; private set; }

        private (string, char)[] Codes { get; set; }

        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            Output = default;
            Codes = codes;
        }

        public override void Review()
        {
            string str = Input;
            foreach (var (code, placeholder) in Codes)
            {
                str = str.Replace(placeholder.ToString(), code);
            }
            Output = str;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}
