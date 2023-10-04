namespace A
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
            // index
            for (int i = 0;i < number; i++)
            {
                Console.WriteLine("So thu {0} la: {1}",i , arrays[i]);
            }
            // pull/ merge request
            Console.Write("Tong la: " + TinhTongSoNguyenTo(arrays));
            // ham tinh tong
            // ham tinh tong so nguyen to trong mang
            // ham tinh tong so hoan hao
            // 6 la so hoan hao vi` 6 co uoc la 1 2 3. va 1 + 2 +3 = 6
            // sang so nguyen to
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
                for (int j = 1; j <= arrays[i]; j++)
                {
                    if (arrays[i] % j == 0)
                    {
                        SoUoc += 1;
                    }
                } 
                if (SoUoc == 2)
                {
                    sum += arrays[i];
                }
            }
            return sum;
        }
    }
}
