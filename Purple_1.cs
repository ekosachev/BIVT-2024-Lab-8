namespace Lab_8
{
    public class Purple_1 : Purple
    {
        public string Output { get; private set; }
        private static char[] SEPARATORS =
        {
            '.',
            '!',
            '?',
            ',',
            ':',
            '\"',
            ';',
            '–',
            '(',
            ')',
            '[',
            ']',
            '{',
            '}',
            '/',
            ' ',
        };

        public Purple_1(string input)
            : base(input)
        {
            this.Output = default;
        }

        public override void Review()
        {
            string[] words = this.Input.Split(SEPARATORS);
            string[] reversed_words = words
                .Select(s =>
                    s.Any(c => "0123456789".Contains(c))
                        ? new string(s)
                        : new string(s.Reverse().ToArray())
                )
                .ToArray();
            string concatenated_words = reversed_words.Aggregate((w1, w2) => w1 + w2);
            int k = 0;
            for (int i = 0; i < this.Input.Length; i++)
            {
                if (SEPARATORS.Contains(this.Input[i]))
                {
                    this.Output += this.Input[i];
                }
                else
                {
                    this.Output += concatenated_words[k++];
                }
            }
        }

        public override string ToString()
        {
            return this.Output;
        }
    }
}
