using System.ComponentModel.Design;
using System.Net.Mail;

namespace Array
{
    public class Program
    {
        static public void SoLanXuatHienCuaPhanTu_C3(List<int> arrays1)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (var number in arrays1)
            {
                if (!keyValuePairs.ContainsKey(number))
                {
                    keyValuePairs.Add(number, 1);
                }
                else
                {
                    keyValuePairs.TryGetValue(number, out int value);
                    keyValuePairs[number]++;
                }
            }
            foreach (var number in keyValuePairs.Keys)
            {
                Console.WriteLine("Number {0}: tan suat {1}", number, keyValuePairs[number]);
            }
        }
    }
}
