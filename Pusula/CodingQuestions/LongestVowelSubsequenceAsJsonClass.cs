using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pusula
{
    public class LongestVowelSubsequenceAsJsonClass
    {
        public static string LongestVowelSubsequenceAsJson(List<string> words)
        {
            if (words == null || words.Count == 0)
                return JsonSerializer.Serialize(new List<object>());

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u',
                                         'A', 'E', 'I', 'O', 'U' };

            var result = new List<object>();

            foreach (var word in words)
            {
                string longestSeq = "";
                string currentSeq = "";

                foreach (char c in word)
                {
                    if (vowels.Contains(c))
                    {
                        currentSeq += c;
                        if (currentSeq.Length > longestSeq.Length)
                            longestSeq = currentSeq;
                    }
                    else
                    {
                        currentSeq = "";
                    }
                }

                result.Add(new
                {
                    word = word,
                    sequence = longestSeq,
                    length = longestSeq.Length
                });
            }

            return JsonSerializer.Serialize(result);
        }
    }
}
