namespace Purple_2
{
    public class Purple_2 : Purple.Purple
    {
        public string[] Output { get; private set; }

        public Purple_2(string input)
            : base(input)
        {
            this.Output = new string[0];
        }

        public override void Review()
        {
            var words = this.Input.Split(' ');
            string[] line = new string[0];
            int wordsAdded = 0;

            while (true)
            {
                int lineLength = line.Select(w => w.Length).Sum() + line.Length - 1;
                int newWordLength = words[wordsAdded].Length;

                if (lineLength + newWordLength >= 50) // Finished current line
                {
                    int amountOfSpaces = line.Length - 1;
                    int spaceToFill = 50 - line.Select(w => w.Length).Sum();
                    int stdSpaceLength = spaceToFill / amountOfSpaces;
                    int amountOfLongerSpaces = spaceToFill - stdSpaceLength * amountOfSpaces;
                    string lineString = "";
                    for (int index = 0; index < line.Length; index++)
                    {
                        string word = line[index];
                        lineString += word;
                        if (index == line.Length - 1)
                        {
                            break;
                        }
                        for (int i = 0; i < stdSpaceLength; i++)
                        {
                            lineString += ' ';
                        }
                        if (index < amountOfLongerSpaces)
                        {
                            lineString += ' ';
                        }
                    }
                    Console.WriteLine($"amount of spaces: {amountOfSpaces}; spaceToFill: {spaceToFill}; stdSpaceLength: {stdSpaceLength}; amountOfLongerSpaces: {amountOfLongerSpaces}");
                    this.Output = this.Output.Append(lineString).ToArray();
                    line = [];
                }
                else
                { // Continue building current line
                    Array.Resize(ref line, line.Length + 1);
                    line[line.Length - 1] = words[wordsAdded++];
                    if (wordsAdded >= words.Length)
                    {
                        if (line.Length != 0)
                        {
                            int amountOfSpaces = line.Length - 1;
                            int spaceToFill = 50 - line.Select(w => w.Length).Sum();
                            int stdSpaceLength = spaceToFill / amountOfSpaces;
                            int amountOfLongerSpaces = spaceToFill - stdSpaceLength * amountOfSpaces;
                            string lineString = "";
                            for (int index = 0; index < line.Length; index++)
                            {
                                string word = line[index];
                                lineString += word;
                                if (index == line.Length - 1)
                                {
                                    break;
                                }
                                for (int i = 0; i < stdSpaceLength; i++)
                                {
                                    lineString += ' ';
                                }
                                if (index < amountOfLongerSpaces)
                                {
                                    lineString += ' ';
                                }
                            }
                            Console.WriteLine($"amount of spaces: {amountOfSpaces}; spaceToFill: {spaceToFill}; stdSpaceLength: {stdSpaceLength}; amountOfLongerSpaces: {amountOfLongerSpaces}");
                            this.Output = this.Output.Append(lineString).ToArray();
                        }
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Join('\n', this.Output);
        }
    }
}
