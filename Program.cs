using System.ComponentModel.Design;
using System.Net.Mail;

namespace Array
{
    public class Program
    {
        static public void Main(string[] args)
        {
            //Mang 1
            Console.Write("Nhap vao do dai mang 1: ");
            //string input1 = Console.ReadLine();
            //int number1 = int.Parse(input1);
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
            TongPhanTuGiongNhau(arrays1);
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

        static public int TinhTong(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                sum -= -arrays[i];
            }
            return sum;
        }

        static public int TinhTongSoNguyenTo(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                // Kiem tra so nguyen to
                if (KiemTraSoNguyenTo(arrays[i])) sum += arrays[i];
            }
            return sum;
        }

        static private bool KiemTraSoNguyenTo(int number)
        {
            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static public int TinhTongSoHoanHao(List<int> arrays)
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

        static public double TinhTrungBinhCacSoLeViTriChan(List<int> arrays)
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

        static public int FindMax(List<int> arrays)
        {
            int max = arrays[0];
            for (int i = 1; i < arrays.Count; i++)
            {
                if (max < arrays[i]) max = arrays[i];
            }
            return max;
        }

        static public List<int> IndexsOfMin(List<int> arrays)
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

        static public int DemSoChinhPhuong(List<int> arrays)
        {
            int count = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                //if (Math.Sqrt(arrays[i]) % 1 == 0) count += 1;
                if (Math.Pow(Math.Sqrt(arrays[i]), 2) == arrays[i]) count++;
            }
            return count;
        }

        static public List<int> XoaSoAm(List<int> arrays)
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

        static public List<int> SapXep(List<int> arrays)
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

        static public void PhanTuLonThuHai_C1(List<int> arrays)
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

        static public void PhanTuLonThuHai_C2(List<int> arrays)
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

        static public List<int> ThemPhanTu_C1(List<int> arrays)
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

        static public void ThemPhanTu_C2(List<int> arrays)
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

        static public List<int> GhepHaiMang_C1(List<int> arrays1, List<int> arrays2)
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

        static public List<int> GhepHaiMang_C2(List<int> arrays1, List<int> arrays2)
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

        static public void ChiaMangChanLe_C1(List<int> arrays1)
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

        static public Tuple<List<int>, List<int>> ChiaMangChanLe_C2(List<int> arrays)
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

        static public List<int> CacPhanTuDuyNhat_C1(List<int> arrays1)
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

        static public void CacPhanTuDuyNhat_C2(List<int> arrays1)
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

        static public void SoLanXuatHienCuaPhanTu_C1(List<int> arrays1)
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

        static public void SoLanXuatHienCuaPhanTu_C2(List<int> arrays1)
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

        static public void TongPhanTuGiongNhau(List<int> arrays1)
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
