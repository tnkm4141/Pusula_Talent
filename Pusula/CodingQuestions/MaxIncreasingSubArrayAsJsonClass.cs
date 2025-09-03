using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Pusula
{
    public class MaxIncreasingSubArrayAsJsonClass
    {
        public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return JsonSerializer.Serialize(new List<int>());

            List<int> bestSubArray = new List<int>();
            int bestSum = int.MinValue;

            List<int> currentSubArray = new List<int>();
            int currentSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (currentSubArray.Count == 0 || numbers[i] > currentSubArray.Last())
                {
                    currentSubArray.Add(numbers[i]);
                    currentSum += numbers[i];
                }
                else
                {
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestSubArray = new List<int>(currentSubArray);
                    }
                    currentSubArray.Clear();
                    currentSubArray.Add(numbers[i]);
                    currentSum = numbers[i];
                }
            }

            // Döngü bittikten sonra son alt dizi için
            if (currentSum > bestSum)
            {
                bestSubArray = new List<int>(currentSubArray);
            }

            return JsonSerializer.Serialize(bestSubArray);
        }
    }
}
