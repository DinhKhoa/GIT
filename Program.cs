using System.Net.Mail;

namespace Array
{
    public class Program
    {
        static public void Main(string[] args)
        {
            // ham nham mang 1 chieu
            // nhap n la do dai` mang, va nhap n phan tu
            Console.Write("Nhap vao do dai n: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            List<int> arrays = new List<int>();
            // nhap n phan tu 
            for (int i = 0; i < number; i++)
            {
                Console.Write("Nhap phan tu thu {0}: ", i);
                int value = int.Parse(Console.ReadLine());
                arrays.Add(value);
            }        
            // Hien thi danh sach mang
            // snippet
            for (int i = 0;i < number; i++)
            {
                Console.WriteLine("So thu {0} la: {1}",i , arrays[i]);
            }
            List<int> result = XoaSoAm(arrays);
            Console.WriteLine("~~~~");
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            //
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
            for (int i = 0;i < arrays.Count; i++)
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
            for (int i = 0; i < arrays.Count; i+=2)
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
            for (int i = 1; i< arrays.Count; i++)
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
    }
}
