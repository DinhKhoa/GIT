using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace BTBacktracking
{
    public class Program
    {
        private static List<int> result;
        private static List<bool> dcx;
        private static List<bool> dcn;
        private static List<bool> checkColumn;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            result = new List<int>(Enumerable.Repeat(0, n));
            dcx = new List<bool>(Enumerable.Repeat(false, 2 * n - 1));
            dcn = new List<bool>(Enumerable.Repeat(false, 2 * n - 1));
            checkColumn = new List<bool>(Enumerable.Repeat(false, n));
            BaiToanConHau(0, n);
            //InBanCoConHau();
            //List<int> result = new List<int>(Enumerable.Repeat(0, k));
            ////List<char> resultChars = new List<char>(Enumerable.Repeat('a', n));
            //List<bool> check = new List<bool>(Enumerable.Repeat(false, n));
            //InChapKCuaNPhanTu(0, n, k, result, check);
        }
        
        public static void InNhiPhanDoDaiN(int k, int n, List<int> result)
        {
            for (int i = 0; i <= 1; i++)
            {
                result[k] = i;
                if (k == n - 1) InKetQua(result);
                else InNhiPhanDoDaiN(k + 1, n, result);
            }
        }
        private static void InKetQua(List<int> result)
        {
            foreach(var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public static void InXauGomChuABCDoDaiN(int k, int n, List<char> resultChars)
        {
            for (char ch = 'a'; ch <= 'c'; ch++)
            {
                resultChars[k] = ch;
                if (k == n - 1) InKetQuaStrings(resultChars);
                else InXauGomChuABCDoDaiN(k + 1, n, resultChars);
            }
        }
        private static void InKetQuaStrings(List<char> result)
        {
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public static void InHoanVi(int k, int n, List<int> result, List<bool> check)
        {
            for (int i = 1; i <= n; i++)
            {
                if (!check[i - 1])
                {
                    result[k] = i;
                    check[i - 1] = true;
                    if (k == n - 1) InKetQua(result);
                    else InHoanVi(k + 1, n, result, check);
                    check[i - 1] = false;
                }
            }
        }

        public static void InChapKCuaNPhanTu(int z, int n, int k, List<int> result, List<bool> check)
        {
            for (int i = 1; i <= n; i++)
            {
                if (!check[i - 1])
                {
                    result[z] = i;
                    check[i - 1] = true;
                    if (z == k - 1) InKetQua(result);
                    else InChapKCuaNPhanTu(z + 1, n, k, result, check);
                    check[i - 1] = false;
                }
            }
        }

        public static void BaiToanConHau(int cot, int n)
        {
            for (int hang = 0; hang < n; hang++)
            {
                if (!checkColumn[cot] && !dcx[n - 1 - (hang - cot)] && !dcn[hang + cot])
                {
                    result[cot] = hang;
                    checkColumn[cot] = true;
                    dcx[n - 1 - (hang - cot)] = true;
                    dcn[hang + cot] = true;
                    if (cot == n - 1) InBanCoConHau();
                    else BaiToanConHau(cot + 1, n);
                    checkColumn[cot] = false;
                    dcx[n - 1 - (hang - cot)] = false;
                    dcn[hang + cot] = false;
                }
            }
        }
        private static void InBanCoConHau()
        {
            for (int hang = 0; hang < result.Count; hang++)
            {
                for (int cot = 0; cot < result.Count; cot++)
                {
                    if (result[hang] == cot) Console.Write("X ");
                    else Console.Write("o ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~");
        }
        private static void InResult()
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("{0} ",result[i]);
            }
            Console.WriteLine();
        }
    }
}