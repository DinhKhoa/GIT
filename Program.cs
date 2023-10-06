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
            // pull/ merge request
            Console.Write("Tong la: " + DemSoChinhPhuong(arrays));
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
            for (int i =0; i < arrays.Count; i++)
            {
                // Kiem tra so nguyen to
                int SoUoc = 0;
                for (int j = 2; j <= (arrays[i]/2); j++)
                {
                    if (arrays[i] % j == 0) SoUoc += 1;
                } 
                if (SoUoc == 0) sum += arrays[i];
            }
            return sum;
        }

        static public int TinhTongSoHoanHao(List<int> arrays)
        {
            int sum = 0;
            for (int i = 0;i < arrays.Count; i++)
            {
                int TongUoc = 0;
                for (int j = 1; j < arrays[i]; j++)
                {
                    if (arrays[i] % j == 0) TongUoc += j;
                }
                if (arrays[i] == TongUoc) sum += arrays[i];
            }
            return sum;
        }

        static public int TinhTrungBinhCacSoLeViTriChan(List<int> arrays)
        {
            int sum = 0; 
            int dem = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                if ( i % 2 == 0)
                {
                    if (arrays[i] % 2 != 0)
                    {
                        sum += arrays[i];
                        dem += 1;
                    }
                }
            }
            return ( sum / dem );
        }

        static public int GTLN(List<int> arrays)
        {
            int max = 0;
            for (int i =0; i< arrays.Count; i++)
            {
                if (max < arrays[i]) max = arrays[i];
            }
            return max;
        }

        static public int ViTriGTNN(List<int> arrays)
        {
            int timmax = GTLN(arrays);
            int min = timmax;
            int vitri = 0;
            for (int i =0; i < arrays.Count; i++)
            {
                if (min > arrays[i]) min = arrays[i];
            }
            for (int i= 0; i < arrays.Count; i++)
            {
                if (min == arrays[i]) vitri = i;
            }
            return vitri;
        }

        static public int DemSoChinhPhuong(List<int> arrays)
        {
            int dem = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                if (Math.Sqrt(arrays[i]) % 1 == 0) dem += 1;
            }
            return dem;
        }

        static public int ThayTheSoAm(List<int> arrays)
        {
            for (int i = 0; i < arrays.Count; i++)
            {
                if (arrays[i]<0) arrays[i] = 0;
            }
        }
    }
}
