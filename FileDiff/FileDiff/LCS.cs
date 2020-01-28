using System;
using System.Text;

namespace FileDiff
{
    public class LCS
    {
        private string s1, s2;
        private int[,] DP;
        private StringBuilder sequence = new StringBuilder();
        public LCS(string S1, string S2)
        {
            DP = new int[S1.Length + 1, S2.Length + 1];
            s1 = S1;
            s2 = S2;
            this.Length();
        }

        public int Length()
        {
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        DP[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                    else
                        DP[i, j] = Math.Max(DP[i - 1, j], DP[i, j - 1]);
                }
            }

            return DP[s1.Length, s2.Length];
        }

        public string LongestSequence()
        {
            int index = DP[s1.Length, s2.Length];
            char[] lcs = new char[index + 1];
            lcs[index] = '\0';
            int k = s1.Length, l = s2.Length;
            while (k > 0 && l > 0)
            {
                if (s1[k - 1] == s2[l - 1])
                {
                    lcs[index - 1] = s1[k - 1];
                    k--;
                    l--;
                    index--;
                }

                else if (DP[k - 1, l] > DP[k, l - 1])
                    k--;
                else
                    l--;
            }

            foreach (char c in lcs)
            {
                if (c != '\0')
                    sequence.Append(c);
            }

            return sequence.ToString();
        }
    }
}
