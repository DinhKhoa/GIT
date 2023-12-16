using System.ComponentModel.Design;
using System.Net.Mail;

namespace BTArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap vao do dai mang 1: ");
            int number1 = int.Parse(Console.ReadLine());
            List<int> arrays1 = new List<int>();
            for (int i = 0; i < number1; i++)
            {
                Console.Write("Nhap phan tu thu {0}: ", i);
                int value1 = int.Parse(Console.ReadLine());
                arrays1.Add(value1);
            }
            for (int i = 0; i < number1; i++)
            {
                Console.WriteLine("So thu {0} la: {1}", i, arrays1[i]);
            }
            ////Mang 2
            //Console.Write("Nhap vao do dai mang 2: ");
            //int number2 = int.Parse(Console.ReadLine());
            //List<int> arrays2 = new List<int>();
            //for (int i = 0; i < number2; i++)
            //{
            //    Console.Write("Nhap phan tu thu {0}: ", i);
            //    int value2 = int.Parse(Console.ReadLine());
            //    arrays2.Add(value2);
            //}

            //Goi ham
            //TongPhanTuGiongNhau(arrays1);

            Console.WriteLine("~~~~");
            //List<int> result = GhepHaiMang_C2(arrays1, arrays2);
            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}
            //for (int i = 0; i < arrays.Count; i++)
            //{
            //    Console.WriteLine(arrays[i]);
            //}
            //Console.WriteLine("~~~SAu khi chay ham~~~");
            //for (int i = 0; i < arrays.Count ; i++)
            //{
            //    Console.WriteLine(arrays[i]);
            //}

            // value type || reference type

            //Console.Write("Gia tri lon nhat la " + GTLN(arrays))
            // ham tinh tong
            // ham tinh tong so nguyen to trong mang
            // ham tinh tong so hoan hao
            // 6 la so hoan hao vi` 6 co uoc la 1 2 3. va 1 + 2 +3 = 6
        }

        // Bai 1
        public static int TinhTong(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                sum -= -arrays[i];
            }
            return sum;
        }

        // Bai 2
        public static int TinhTongSoNguyenTo(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                // Kiem tra so nguyen to
                if (KiemTraSoNguyenTo(arrays[i])) sum += arrays[i];
            }
            return sum;
        }
        private static bool KiemTraSoNguyenTo(int number)
        {
            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Bai 3
        public static int TinhTongSoHoanHao(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                int tongUoc = 0;
                for (int j = 1; j < arrays[i] / 2; j++)
                {
                    if (arrays[i] % j == 0) tongUoc += j;
                }
                if (arrays[i] == tongUoc) sum += arrays[i];
            }
            return sum;
        }

        // Bai 4
        public static double TinhTrungBinhCacSoLeViTriChan(List<int> arrays)
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < arrays.Count; i += 2)
            {
                if (arrays[i] % 2 != 0)
                {
                    sum += arrays[i];
                    count += 1;
                }
            }
            return ((double)sum / count);
        }

        // Bai 5
        public static int FindMax(List<int> arrays)
        {
            int max = arrays[0];
            for (int i = 1; i < arrays.Count; i++)
            {
                if (max < arrays[i]) max = arrays[i];
            }
            return max;
        }

        // Bai 6
        public static List<int> IndexsOfMin(List<int> arrays)
        {
            List<int> indexs = new List<int>();
            int min = arrays[0];
            for (int i = 1; i < arrays.Count; i++)
            {
                if (min > arrays[i]) min = arrays[i];
            }
            for (int i = 0; i < arrays.Count; i++)
            {
                if (min == arrays[i]) indexs.Add(i);
            }
            return indexs;
        }

        // Bai 7
        public static int DemSoChinhPhuong(List<int> arrays)
        {
            int count = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                //if (Math.Sqrt(arrays[i]) % 1 == 0) count += 1;
                if (Math.Pow(Math.Sqrt(arrays[i]), 2) == arrays[i]) count++;
            }
            return count;
        }

        // Bai 8
        public static List<int> XoaSoAm(List<int> arrays)
        {
            //List<int> result = new List<int>();
            //for (int i = 0; i < arrays.Count; i++)
            //{
            //    if (arrays[i] >= 0) result.Add(i);
            //}
            //return result;
            // 1 2 -3 -4 -5
            // 1 2 -4 -5 -5
            // 1 2 -4 -5
            // 1 2 -5

            // length 3 arrays.Count 5;
            for (int i = 0; i < arrays.Count; i++)
            {
                if (arrays[i] < 0)
                {
                    //// remove arrays[i]
                    //for (int j = i; j < arrays.Count -1 ; j++)
                    //{
                    //    arrays[j] = arrays[j + 1];
                    //}
                    //i--;
                    //arrays.RemoveRange(arrays.Count - 1, 1);
                    arrays.RemoveRange(i, 1); // Remove at
                    i--;
                }
            }
            //for (int i = 0; i < length; i++)
            //{
            //    Console.WriteLine(arrays[i]);
            //}
            return arrays;
        }

        // Bai 9
        public static List<int> SapXep(List<int> arrays)
        {
            // sap xep tang dan
            for (int i = 0; i < arrays.Count - 1; i++)
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    if (arrays[i] > arrays[j])
                    {
                        // swap 2 so
                        int temp = arrays[i];
                        arrays[i] = arrays[j];
                        arrays[j] = temp;
                    }

                }
            return arrays;
        }

        // Bai 10
        public static void PhanTuLonThuHai_C1(List<int> arrays)
        {
            int count = 0;
            for (int i = 0; i < arrays.Count - 1; i++)
            {
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    if (arrays[i] > arrays[j])
                    {
                        int temp = arrays[i];
                        arrays[i] = arrays[j];
                        arrays[j] = temp;
                    }
                }
            }
            for (int i = arrays.Count - 2; i >= 0; i--)
            {
                if (arrays[arrays.Count - 1] == arrays[i]) count++;
            }
            if (count != arrays.Count - 1)
            {
                Console.WriteLine(arrays[arrays.Count - 2 - count]);
            }
            else
            {
                Console.WriteLine("Khong co phan tu lon thu hai");
            }
        }
        public static void PhanTuLonThuHai_C2(List<int> arrays)
        {
            for (int i = 0; i < arrays.Count - 1; i++)
            {
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    if (arrays[i] > arrays[j])
                    {
                        int temp = arrays[i];
                        arrays[i] = arrays[j];
                        arrays[j] = temp;
                    }
                }
            }
            // unique array
            List<int> uniqueArrays = new List<int>();
            uniqueArrays.Add(arrays[0]);
            for (int i = 1; i < arrays.Count; i++)
            {
                if (!uniqueArrays.Contains(arrays[i])) uniqueArrays.Add(arrays[i]);
            }
            if (uniqueArrays.Count == 1)
            {
                Console.WriteLine("Khong co second max");
            }
            else
            {
                Console.WriteLine(uniqueArrays[uniqueArrays.Count - 2]);
            }
        }

        // Bai 11
        public static List<int> ThemPhanTu_C1(List<int> arrays)
        {
            List<int> result = new List<int>();
            Console.Write("Nhap gia tri: ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("Vi tri: ");
            int index = int.Parse(Console.ReadLine());
            for (int i = 0; i < arrays.Count; i++)
            {
                if (i == index)
                {
                    result.Add(value);
                    for (int j = i; j < arrays.Count; j++)
                    {
                        result.Add(arrays[j]);
                    }
                    break;
                }
                else
                {
                    result.Add(arrays[i]);
                }
            }
            if (index > arrays.Count - 1) result.Add(value);
            return result;
        }
        public static void ThemPhanTu_C2(List<int> arrays)
        {
            Console.WriteLine("Nhap gia tri:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vi tri:");
            int index = int.Parse(Console.ReadLine());
            arrays.Add(0);
            for (int i = arrays.Count - 1; i > index; i--)
            {
                arrays[i] = arrays[i - 1];
            }
            arrays[index] = number;
        }

        // Bai 12
        public static List<int> GhepHaiMang_C1(List<int> arrays1, List<int> arrays2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arrays1.Count; i++)
            {
                result.Add(arrays1[i]);
            }
            for (int i = 0; i < arrays2.Count; i++)
            {
                result.Add(arrays2[i]);
            }
            return result;
        }
        public static List<int> GhepHaiMang_C2(List<int> arrays1, List<int> arrays2)
        {
            List<int> result = new List<int>(new int[arrays1.Count + arrays2.Count]);
            for (int i = 0; i < arrays1.Count; i++)
            {
                result[i] = arrays1[i];
            }
            for (int j = arrays1.Count; j < result.Count; j++)
            {
                result[j] = arrays2[j - arrays1.Count];
            }
            return result;
        }

        // Bai 13
        public static void ChiaMangChanLe_C1(List<int> arrays1)
        {
            Console.WriteLine("~~~ Chan ~~~");
            for (int i = 0; i < arrays1.Count; i++)
            {
                if (arrays1[i] % 2 == 0) Console.WriteLine(arrays1[i]);
            }
            Console.WriteLine("~~~ Le ~~~");
            for (int i = 0; i < arrays1.Count; i++)
            {
                if (arrays1[i] % 2 != 0) Console.WriteLine(arrays1[i]);
            }
        }
        public static Tuple<List<int>, List<int>> ChiaMangChanLe_C2(List<int> arrays)
        {
            // thay so chan bang so 0
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            foreach (var number in arrays)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }
            return Tuple.Create(evenNumbers, oddNumbers);
        }

        // Bai 14
        public static List<int> CacPhanTuDuyNhat_C1(List<int> arrays1)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arrays1.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < arrays1.Count; j++)
                {
                    if (arrays1[i] == arrays1[j] && i != j) count++;
                }
                if (count == 0) result.Add(arrays1[i]);
            }
            return result;
        }
        public static void CacPhanTuDuyNhat_C2(List<int> arrays1)
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
            //foreach (var number in keyValuePairs.Keys)
            //{
            //    Console.WriteLine("Number {0}: tan suat {1}", number, keyValuePairs[number]);
            //}
            foreach (var number in keyValuePairs.Keys)
            {
                if (keyValuePairs[number] == 1)
                {
                    Console.WriteLine("Phan tu: {0} la duy nhat", number);
                }
            }
        }

        // Bai 15
        public static void SoLanXuatHienCuaPhanTu_C1(List<int> arrays1)
        {
            for (int i = 0; i < arrays1.Count; i++)
            {
                int count = 1;
                for (int j = i + 1; j < arrays1.Count; j++)
                {
                    if (arrays1[i] == arrays1[j] && i != j)
                    {
                        count++;
                        arrays1.RemoveAt(j);
                    }
                }
                Console.WriteLine("Phan tu {0} xuat hien {1} lan", arrays1[i], count);
            }
        }
        public static void SoLanXuatHienCuaPhanTu_C2(List<int> arrays1)
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

        // Bai 16
        public static void TongPhanTuGiongNhau(List<int> arrays1)
        {
            int sum = 0;
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
                if (keyValuePairs[number] != 1) sum += keyValuePairs[number];
            }
            Console.WriteLine(sum);
        }
    }
}
