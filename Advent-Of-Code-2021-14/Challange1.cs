namespace AdventOfCode.Day14
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public static class Challange1
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static long DoChallange(string input)
        {
            //Parse the input into set of chemical bonds (pairs) and rules.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            Dictionary<string, long> chemicalBonds = new();

            for (int letter = 0; letter < inputData[0].Length - 1; letter++)
            {
                string bond = inputData[0].Substring(letter, 2);
                if (chemicalBonds.ContainsKey(bond))
                {
                    chemicalBonds[bond]++;
                }
                else
                {
                    chemicalBonds.Add(bond, 1);
                }
            }

            List<Rule> rules = new();

            for (int inputLine = 2; inputLine < inputData.Length; inputLine++)
            {
                string[] line = inputData[inputLine].Split(" -> ");
                rules.Add(new Rule(line[0], line[1][0]));
            }

            //Repeat 10 times
            for (int step = 0; step < 10; step++)
            {
                Dictionary<string, long> newChemicalBonds = new();
                
                //For every chemical bond in original list, add two new bonds according to applying rules and remove itself
                //Since I'm keeping count of how many times chemical bond appeared, add or remove that amount from new list
                foreach (string bond in chemicalBonds.Keys)
                {
                    if (chemicalBonds[bond] == 0)
                        continue;
                    foreach (Rule rule in rules)
                    {
                        if (rule.Origin != bond)
                            continue;

                        string bond1 = bond[0] + "" + rule.Target;
                        string bond2 = rule.Target + "" + bond[1];

                        if (newChemicalBonds.ContainsKey(bond1))
                            newChemicalBonds[bond1] += chemicalBonds[bond];
                        else
                            newChemicalBonds.Add(bond1, chemicalBonds[bond]);

                        if (newChemicalBonds.ContainsKey(bond2))
                            newChemicalBonds[bond2] += chemicalBonds[bond];
                        else
                            newChemicalBonds.Add(bond2, chemicalBonds[bond]);

                        if (newChemicalBonds.ContainsKey(bond))
                            newChemicalBonds[bond] -= chemicalBonds[bond];
                        else
                            newChemicalBonds.Add(bond, -chemicalBonds[bond]);

                        break;
                    }
                }

                //Apply list of changes into original list
                foreach (string bond in newChemicalBonds.Keys)
                {
                    if (chemicalBonds.ContainsKey(bond))
                        chemicalBonds[bond] += newChemicalBonds[bond];
                    else
                        chemicalBonds.Add(bond, newChemicalBonds[bond]);
                }
            }

            //Count how many times each element in chemical appears. last element in original input is added to list for simplicity.
            Dictionary<char, long> elements = new() { { inputData[0][^1], 1 } };

            for (int i = 0; i < chemicalBonds.Count; i++)
            {
                string bond = chemicalBonds.Keys.ElementAt(i);
                char c = bond[0];
                if (elements.ContainsKey(c))
                    elements[c] += chemicalBonds[bond];
                else
                    elements.Add(c, chemicalBonds[bond]);
            }

            //Find most common and least common elements.
            char mostCommon = elements.First().Key;
            char leastCommon = elements.First().Key;

            foreach (char c in elements.Keys)
            {
                if (elements[c] > elements[mostCommon]) mostCommon = c;
                if (elements[c] < elements[leastCommon]) leastCommon = c;
            }

            return elements[mostCommon] - elements[leastCommon];
        }
    }
}