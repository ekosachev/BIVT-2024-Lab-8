using System.Text;

namespace Purple_3
{
    public class Purple_3 : Purple.Purple
    {
        public (string, char)[] Codes { get; private set; }
        public string Output { get; private set; }

        public Purple_3(string input) : base(input)
        {
            Output = "";
            Codes = new (string, char)[0];
        }

        public override void Review()
        {
            var pairs = new Dictionary<string, int>();
            // find the most frequent pairs
            for (int ifirst = 0; ifirst < Input.Length - 1; ifirst++)
            {
                char firstChar = Input[ifirst];
                char secondChar = Input[ifirst + 1];
                if (!char.IsLetter(firstChar) || !char.IsLetter(secondChar))
                    continue;

                var sb = new StringBuilder(2);
                sb.Append(firstChar);
                sb.Append(secondChar);
                string pair = sb.ToString();
                if (pairs.ContainsKey(pair))
                {
                    pairs[pair]++;
                }
                else
                {
                    pairs[pair] = 1;
                }

            }
            var mostFrequentPairs = pairs.AsEnumerable()
                .OrderByDescending(pair => pair.Value)
                .Take(int.Min(pairs.Count(), 5))
                .ToDictionary();

            // foreach (var pair in mostFrequentPairs)
            // {
            //     Console.WriteLine($"{pair.Key}: {pair.Value}");
            // }

            // get available charaters
            int placeholdersNeeded = mostFrequentPairs.Count();
            char[] availablePlaceholders = new char[placeholdersNeeded];
            int placeholdersFound = 0;
            while (true)
            {
                for (int i = 32; i <= 126; i++)
                {
                    char c = (char)i;
                    if (!Input.Contains(c))
                    {
                        availablePlaceholders[placeholdersFound++] = c;
                    }
                    if (placeholdersFound == placeholdersNeeded) break;
                }

                if (placeholdersFound == placeholdersNeeded) break;
            }

            // Console.WriteLine($"Placholders: {string.Join(' ', availablePlaceholders)}");

            Codes = mostFrequentPairs.Select(pair => pair.Key).Zip(availablePlaceholders).ToArray();

            string str = Input;
            foreach (var (code, placeholder) in Codes)
            {
                str = str.Replace(code, placeholder.ToString());
            }
            Output = str;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}
